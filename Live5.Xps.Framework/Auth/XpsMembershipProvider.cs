
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Net;
using System.IO;
using Live5.Xps.Framework.Utils;
using Live5.Xps.Framework.Core;

/*

This provider works with the following schema for the table of user data.

CREATE TABLE Users
(
  PKID Guid NOT NULL PRIMARY KEY,
  Username Text (255) NOT NULL,
  ApplicationName Text (255) NOT NULL,
  Email Text (128) NOT NULL,
  Comment Text (255),
  Password Text (128) NOT NULL,
  PasswordQuestion Text (255),
  PasswordAnswer Text (255),
  IsApproved YesNo, 
  LastActivityDate DateTime,
  LastLoginDate DateTime,
  LastPasswordChangedDate DateTime,
  CreationDate DateTime, 
  IsOnLine YesNo,
  IsLockedOut YesNo,
  LastLockedOutDate DateTime,
  FailedPasswordAttemptCount Integer,
  FailedPasswordAttemptWindowStart DateTime,
  FailedPasswordAnswerAttemptCount Integer,
  FailedPasswordAnswerAttemptWindowStart DateTime
)

*/


namespace Live5.Xps.Framework
{

    public sealed class XpsMembershipProvider : MembershipProvider
    {

        //
        // Global connection string, generated password length, generic exception message, event log info.
        //

        private int newPasswordLength = 8;
        private string eventSource = "XpsMembershipProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string tableName = "Users";
        private string connectionString;

        //
        // Used when determining encryption key values.
        //

        private MachineKeySection machineKey;

        //
        // If false, exceptions are thrown to the caller. If true,
        // exceptions are written to the event log.
        //

        private bool pWriteExceptionsToEventLog;

        public bool WriteExceptionsToEventLog
        {
            get { return pWriteExceptionsToEventLog; }
            set { pWriteExceptionsToEventLog = value; }
        }


        //
        // System.Configuration.Provider.ProviderBase.Initialize Method
        //

        public override void Initialize(string name, NameValueCollection config)
        {
            //
            // Initialize values from web.config.
            //

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "XpsMembershipProvider";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample ODBC Membership provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            pApplicationName = GetConfigValue(config["applicationName"],
                                            System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
            pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "1"));
            pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
            pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
            pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
            pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
            pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
            pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));
            pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "true"));

            string temp_format = config["passwordFormat"];
            if (temp_format == null)
            {
                temp_format = "Hashed";
            }

            switch (temp_format)
            {
                case "Hashed":
                    pPasswordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    pPasswordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    pPasswordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("Password format not supported.");
            }

            //
            // Initialize OdbcConnection.
            //

            ConnectionStringSettings ConnectionStringSettings =
              ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            connectionString = ConnectionStringSettings.ConnectionString;


            // Get encryption and decryption key information from the configuration.
            Configuration cfg =
              WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");
        }


        //
        // A helper function to retrieve config values from the configuration file.
        //

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }


        //
        // System.Web.Security.MembershipProvider properties.
        //


        private string pApplicationName;
        private bool pEnablePasswordReset;
        private bool pEnablePasswordRetrieval;
        private bool pRequiresQuestionAndAnswer;
        private bool pRequiresUniqueEmail;
        private int pMaxInvalidPasswordAttempts;
        private int pPasswordAttemptWindow;
        private MembershipPasswordFormat pPasswordFormat;

        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }

        public override bool EnablePasswordReset
        {
            get { return pEnablePasswordReset; }
        }


        public override bool EnablePasswordRetrieval
        {
            get { return pEnablePasswordRetrieval; }
        }


        public override bool RequiresQuestionAndAnswer
        {
            get { return pRequiresQuestionAndAnswer; }
        }


        public override bool RequiresUniqueEmail
        {
            get { return pRequiresUniqueEmail; }
        }


        public override int MaxInvalidPasswordAttempts
        {
            get { return pMaxInvalidPasswordAttempts; }
        }


        public override int PasswordAttemptWindow
        {
            get { return pPasswordAttemptWindow; }
        }


        public override MembershipPasswordFormat PasswordFormat
        {
            get { return pPasswordFormat; }
        }

        private int pMinRequiredNonAlphanumericCharacters;

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return pMinRequiredNonAlphanumericCharacters; }
        }

        private int pMinRequiredPasswordLength;

        public override int MinRequiredPasswordLength
        {
            get { return pMinRequiredPasswordLength; }
        }

        private string pPasswordStrengthRegularExpression;

        public override string PasswordStrengthRegularExpression
        {
            get { return pPasswordStrengthRegularExpression; }
        }

        //
        // System.Web.Security.MembershipProvider methods.
        //

        //
        // MembershipProvider.ChangePassword
        //

        public override bool ChangePassword(string username, string oldPwd, string newPwd)
        {
            if (!ValidateUser(username, oldPwd))
                return false;


            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, newPwd, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Change password canceled due to new password validation failure.");


            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("UPDATE [" + tableName + "]" +
                    " SET Password = ?, LastPasswordChangedDate = ? " +
                    " WHERE Username = ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@Password", OdbcType.VarChar, 255).Value = EncodePassword(newPwd);
            cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;


            int rowsAffected = 0;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ChangePassword");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }



        //
        // MembershipProvider.ChangePasswordQuestionAndAnswer
        //

        public override bool ChangePasswordQuestionAndAnswer(string username,
                      string password,
                      string newPwdQuestion,
                      string newPwdAnswer)
        {
            if (!ValidateUser(username, password))
                return false;

            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("UPDATE [" + tableName + "]" +
                    " SET PasswordQuestion = ?, PasswordAnswer = ?" +
                    " WHERE Username = ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@Question", OdbcType.VarChar, 255).Value = newPwdQuestion;
            cmd.Parameters.Add("@Answer", OdbcType.VarChar, 255).Value = EncodePassword(newPwdAnswer);
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;


            int rowsAffected = 0;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ChangePasswordQuestionAndAnswer");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }



        //
        // MembershipProvider.CreateUser
        //

        public override MembershipUser CreateUser(string username,
                 string password,
                 string email,
                 string passwordQuestion,
                 string passwordAnswer,
                 bool isApproved,
                 object providerUserKey,
                 out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, password, true);

            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }



            if (RequiresUniqueEmail && GetUserNameByEmail(email) != "")
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser u = GetUser(username, false);

            if (u == null)
            {
                //DateTime createDate = DateTime.Now;

                //if (providerUserKey == null)
                //{
                //    providerUserKey = Guid.NewGuid();
                //}
                //else
                //{
                //    if (!(providerUserKey is Guid))
                //    {
                //        status = MembershipCreateStatus.InvalidProviderUserKey;
                //        return null;
                //    }
                //}

                //OdbcConnection conn = new OdbcConnection(connectionString);
                //OdbcCommand cmd = new OdbcCommand("INSERT INTO [" + tableName + "]" +
                //      " (PKID, Username, Password, Email, PasswordQuestion, " +
                //      " PasswordAnswer, IsApproved," +
                //      " Comment, CreationDate, LastPasswordChangedDate, LastActivityDate," +
                //      " ApplicationName, IsLockedOut, LastLockedOutDate," +
                //      " FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, " +
                //      " FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart)" +
                //      " Values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", conn);

                //cmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey;
                //cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
                //cmd.Parameters.Add("@Password", OdbcType.VarChar, 255).Value = EncodePassword(password);
                //cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = email;
                //cmd.Parameters.Add("@PasswordQuestion", OdbcType.VarChar, 255).Value = passwordQuestion;
                //cmd.Parameters.Add("@PasswordAnswer", OdbcType.VarChar, 255).Value = EncodePassword(passwordAnswer);
                //cmd.Parameters.Add("@IsApproved", OdbcType.Bit).Value = isApproved;
                //cmd.Parameters.Add("@Comment", OdbcType.VarChar, 255).Value = "";
                //cmd.Parameters.Add("@CreationDate", OdbcType.DateTime).Value = createDate;
                //cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = createDate;
                //cmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = createDate;
                //cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;
                //cmd.Parameters.Add("@IsLockedOut", OdbcType.Bit).Value = false;
                //cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = createDate;
                //cmd.Parameters.Add("@FailedPasswordAttemptCount", OdbcType.Int).Value = 0;
                //cmd.Parameters.Add("@FailedPasswordAttemptWindowStart", OdbcType.DateTime).Value = createDate;
                //cmd.Parameters.Add("@FailedPasswordAnswerAttemptCount", OdbcType.Int).Value = 0;
                //cmd.Parameters.Add("@FailedPasswordAnswerAttemptWindowStart", OdbcType.DateTime).Value = createDate;

                //try
                //{
                //    conn.Open();

                //    int recAdded = cmd.ExecuteNonQuery();

                //    if (recAdded > 0)
                //    {
                //        status = MembershipCreateStatus.Success;
                //    }
                //    else
                //    {
                //        status = MembershipCreateStatus.UserRejected;
                //    }
                //}
                //catch (OdbcException e)
                //{
                //    if (WriteExceptionsToEventLog)
                //    {
                //        WriteToEventLog(e, "CreateUser");
                //    }

                //    status = MembershipCreateStatus.ProviderError;
                //}
                //finally
                //{
                //    conn.Close();
                //}

                int result = SqlDbTool.ExecuteNonQuery(Constants.Sp_CreateUser, username, password, email,
                     passwordQuestion, passwordAnswer, isApproved, string.Empty);
                if (result > 0)
                {
                    status = MembershipCreateStatus.Success;
                }
                else
                {
                    status = MembershipCreateStatus.UserRejected;
                }

                u = GetUser(username, false);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }
            return u;
        }



        //
        // MembershipProvider.DeleteUser
        //

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("DELETE FROM [" + tableName + "]" +
                    " WHERE Username = ? AND Applicationname = ?", conn);

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

            int rowsAffected = 0;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();

                if (deleteAllRelatedData)
                {
                    // Process commands to delete all data for the user in the database.
                }
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "DeleteUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
                return true;

            return false;
        }



        //
        // MembershipProvider.GetAllUsers
        //

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT Count(*) FROM [" + tableName + "] " +
                                              "WHERE ApplicationName = ?", conn);
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

            MembershipUserCollection users = new MembershipUserCollection();

            OdbcDataReader reader = null;
            totalRecords = 0;

            try
            {
                conn.Open();
                totalRecords = (int)cmd.ExecuteScalar();

                if (totalRecords <= 0) { return users; }

                cmd.CommandText = "SELECT PKID, Username, Email, PasswordQuestion," +
                         " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                         " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate " +
                         " FROM [" + tableName + "] " +
                         " WHERE ApplicationName = ? " +
                         " ORDER BY Username Asc";

                reader = cmd.ExecuteReader();

                int counter = 0;
                int startIndex = pageSize * pageIndex;
                int endIndex = startIndex + pageSize - 1;

                while (reader.Read())
                {
                    if (counter >= startIndex)
                    {
                        MembershipUser u = GetUserFromReader(reader);
                        users.Add(u);
                    }

                    if (counter >= endIndex) { cmd.Cancel(); }

                    counter++;
                }
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetAllUsers");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                conn.Close();
            }

            return users;
        }


        //
        // MembershipProvider.GetNumberOfUsersOnline
        //

        public override int GetNumberOfUsersOnline()
        {

            TimeSpan onlineSpan = new TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0);
            DateTime compareTime = DateTime.Now.Subtract(onlineSpan);

            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT Count(*) FROM [" + tableName + "]" +
                    " WHERE LastActivityDate > ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@CompareDate", OdbcType.DateTime).Value = compareTime;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

            int numOnline = 0;

            try
            {
                conn.Open();

                numOnline = (int)cmd.ExecuteScalar();
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetNumberOfUsersOnline");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            return numOnline;
        }



        //
        // MembershipProvider.GetPassword
        //

        public override string GetPassword(string username, string answer)
        {
            if (!EnablePasswordRetrieval)
            {
                throw new ProviderException("Password Retrieval Not Enabled.");
            }

            if (PasswordFormat == MembershipPasswordFormat.Hashed)
            {
                throw new ProviderException("Cannot retrieve Hashed passwords.");
            }

            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT Password, PasswordAnswer, IsLockedOut FROM [" + tableName + "]" +
                  " WHERE Username = ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

            string password = "";
            string passwordAnswer = "";
            OdbcDataReader reader = null;

            try
            {
                conn.Open();

                reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.HasRows)
                {
                    reader.Read();

                    if (reader.GetBoolean(2))
                        throw new MembershipPasswordException("The supplied user is locked out.");

                    password = reader.GetString(0);
                    passwordAnswer = reader.GetString(1);
                }
                else
                {
                    throw new MembershipPasswordException("The supplied user name is not found.");
                }
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetPassword");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                conn.Close();
            }


            if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
            {
                UpdateFailureCount(username, "passwordAnswer");

                throw new MembershipPasswordException("Incorrect password answer.");
            }


            if (PasswordFormat == MembershipPasswordFormat.Encrypted)
            {
                password = UnEncodePassword(password);
            }

            return password;
        }



        //
        // MembershipProvider.GetUser(string, bool)
        //

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            IDataReader dr = SqlDbTool.ExecuteQuery(Constants.Sp_GetUserByUserName, username);

            MembershipUser u = null;
            if (dr.Read())
            {
                u = GetUserFromReader(dr);
            }

            if (userIsOnline)
            {
                //OdbcCommand updateCmd = new OdbcCommand("UPDATE [" + tableName + "] " +
                //          "SET LastActivityDate = ? " +
                //          "WHERE Username = ? AND Applicationname = ?", conn);

                //updateCmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = DateTime.Now;
                //updateCmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
                //updateCmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

                //updateCmd.ExecuteNonQuery();
            }

            return u;
        }


        //
        // MembershipProvider.GetUser(object, bool)
        //

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT PKID, Username, Email, PasswordQuestion," +
                  " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                  " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate" +
                  " FROM [" + tableName + "] WHERE PKID = ?", conn);

            cmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey;

            MembershipUser u = null;
            OdbcDataReader reader = null;

            try
            {
                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    u = GetUserFromReader(reader);

                    if (userIsOnline)
                    {
                        OdbcCommand updateCmd = new OdbcCommand("UPDATE [" + tableName + "] " +
                                  "SET LastActivityDate = ? " +
                                  "WHERE PKID = ?", conn);

                        updateCmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = DateTime.Now;
                        updateCmd.Parameters.Add("@PKID", OdbcType.UniqueIdentifier).Value = providerUserKey;

                        updateCmd.ExecuteNonQuery();
                    }
                }

            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetUser(Object, Boolean)");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }

                conn.Close();
            }

            return u;
        }


        //
        // GetUserFromReader
        //    A helper function that takes the current row from the OdbcDataReader
        // and hydrates a MembershiUser from the values. Called by the 
        // MembershipUser.GetUser implementation.
        //

        private MembershipUser GetUserFromReader(IDataReader dr)
        {
            Guid userId = Guid.Empty;
            string userName = null;
            string email = null;
            string passwordQuestion = null;
            string comment = null;
            bool isApproved = false;
            bool isLockedOut = false;

            DateTime createDate = new DateTime();
            DateTime lastLoginDate = new DateTime();

            DateTime lastActivityDate = new DateTime();
            DateTime lastPasswordChangedDate = new DateTime();
            DateTime lastLockOutDate = new DateTime();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals("UserId", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        userId = dr.GetGuid(i);
                    }
                    continue;
                }
                if (dr.GetName(i).Equals("UserName", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        userName = dr.GetString(i);
                    }
                    continue;
                }
                if (dr.GetName(i).Equals("Email", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        email = dr.GetString(i);
                    }
                    continue;
                }
                if (dr.GetName(i).Equals("PasswordQuestion", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        passwordQuestion = dr.GetString(i);
                    }
                    continue;
                }
                if (dr.GetName(i).Equals("Comment", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        comment = dr.GetString(i);
                    }
                }
                if (dr.GetName(i).Equals("IsApproved", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        isApproved = dr.GetBoolean(i);

                    }
                }
                if (dr.GetName(i).Equals("isLockedOut", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        isLockedOut = dr.GetBoolean(i);
                    }
                }
                if (dr.GetName(i).Equals("createDate", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        createDate = dr.GetDateTime(i);
                    }
                }
                if (dr.GetName(i).Equals("lastLoginDate", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        lastLoginDate = dr.GetDateTime(i);
                    }
                }
                if (dr.GetName(i).Equals("lastActivityDate", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        lastActivityDate = dr.GetDateTime(i);
                    }
                }
                if (dr.GetName(i).Equals("lastPasswordChangedDate", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        lastPasswordChangedDate = dr.GetDateTime(i);
                    }
                }
                if (dr.GetName(i).Equals("lastLockOutDate", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        lastLockOutDate = dr.GetDateTime(i);
                    }
                }

            }

            MembershipUser u = new MembershipUser(this.Name,
                                                  userName,
                                                  userId,
                                                  email,
                                                  passwordQuestion,
                                                  comment,
                                                  isApproved,
                                                  isLockedOut,
                                                  createDate,
                                                  lastLoginDate,
                                                  lastActivityDate,
                                                  lastPasswordChangedDate,
                                                  lastLockOutDate);

            return u;
        }


        //
        // MembershipProvider.UnlockUser
        //

        public override bool UnlockUser(string username)
        {
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("UPDATE [" + tableName + "] " +
                                              " SET IsLockedOut = False, LastLockedOutDate = ? " +
                                              " WHERE Username = ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

            int rowsAffected = 0;

            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UnlockUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
                return true;

            return false;
        }


        //
        // MembershipProvider.GetUserNameByEmail
        //

        public override string GetUserNameByEmail(string email)
        {
            string userName = null;
            IDataReader dr = SqlDbTool.ExecuteQuery(Constants.Sp_GetUserNameByEmail, email);
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    userName = dr.GetString(0);
                }
            }
            if (userName == null)
            {
                userName = string.Empty;
            }

            return userName;
        }




        //
        // MembershipProvider.ResetPassword
        //

        public override string ResetPassword(string username, string answer)
        {
            if (!EnablePasswordReset)
            {
                throw new NotSupportedException("Password reset is not enabled.");
            }

            if (answer == null && RequiresQuestionAndAnswer)
            {
                UpdateFailureCount(username, "passwordAnswer");

                throw new ProviderException("Password answer required for password reset.");
            }

            string newPassword =
              System.Web.Security.Membership.GeneratePassword(newPasswordLength, MinRequiredNonAlphanumericCharacters);


            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, newPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Reset password canceled due to password validation failure.");


            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT PasswordAnswer, IsLockedOut FROM [" + tableName + "]" +
                  " WHERE Username = ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

            int rowsAffected = 0;
            string passwordAnswer = "";
            OdbcDataReader reader = null;

            try
            {
                conn.Open();

                reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.HasRows)
                {
                    reader.Read();

                    if (reader.GetBoolean(1))
                        throw new MembershipPasswordException("The supplied user is locked out.");

                    passwordAnswer = reader.GetString(0);
                }
                else
                {
                    throw new MembershipPasswordException("The supplied user name is not found.");
                }

                if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
                {
                    UpdateFailureCount(username, "passwordAnswer");

                    throw new MembershipPasswordException("Incorrect password answer.");
                }

                OdbcCommand updateCmd = new OdbcCommand("UPDATE [" + tableName + "]" +
                    " SET Password = ?, LastPasswordChangedDate = ?" +
                    " WHERE Username = ? AND ApplicationName = ? AND IsLockedOut = False", conn);

                updateCmd.Parameters.Add("@Password", OdbcType.VarChar, 255).Value = EncodePassword(newPassword);
                updateCmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = DateTime.Now;
                updateCmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
                updateCmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

                rowsAffected = updateCmd.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ResetPassword");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                conn.Close();
            }

            if (rowsAffected > 0)
            {
                return newPassword;
            }
            else
            {
                throw new MembershipPasswordException("User not found, or user is locked out. Password not Reset.");
            }
        }


        //
        // MembershipProvider.UpdateUser
        //

        public override void UpdateUser(MembershipUser user)
        {
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("UPDATE [" + tableName + "]" +
                    " SET Email = ?, Comment = ?," +
                    " IsApproved = ?" +
                    " WHERE Username = ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@Email", OdbcType.VarChar, 128).Value = user.Email;
            cmd.Parameters.Add("@Comment", OdbcType.VarChar, 255).Value = user.Comment;
            cmd.Parameters.Add("@IsApproved", OdbcType.Bit).Value = user.IsApproved;
            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = user.UserName;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;


            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UpdateUser");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public override bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("username cannot be null or empty.", "username");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("password cannot be null or empty.", "password");
            }

            if (username.EndsWith("@gmail.com", StringComparison.InvariantCultureIgnoreCase))
            {
                return ValidateGmailUser(username, password);
            }
            else
            {
                return true;
            }
        }

        private bool ValidateLocalUser(string username, string password)
        {
            return true;
        }
        private bool ValidateGmailUser(string username, string password)
        {
            bool isValid = false;
            HttpWebRequest request = WebRequest.Create("https://www.google.com/accounts/ClientLogin") as HttpWebRequest;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            StreamWriter writer = new StreamWriter(requestStream);
            writer.Write("accountType=HOSTED_OR_GOOGLE&Email=" + username + "&Passwd=" + password + "&service=cl&source=Live5-Test-1.05");
            writer.Flush();
            writer.Close();
            HttpWebResponse response = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (System.Net.WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    return isValid;
                }
                throw;
            }

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string[] results = new string[10];
            int i = 0;
            while (!reader.EndOfStream)
            {
                results[i] = reader.ReadLine();
                i++;
            }

            if (results[0].Length != 0)
            {
                isValid = true;
            }
            return isValid;
        }


        //
        // MembershipProvider.ValidateUser
        //
        /* Old code.
      public override bool ValidateUser(string username, string password)
      {
        bool isValid = false;

        OdbcConnection conn = new OdbcConnection(connectionString);
        OdbcCommand cmd = new OdbcCommand("SELECT Password, IsApproved FROM [" + tableName + "]" +
                " WHERE Username = ? AND ApplicationName = ? AND IsLockedOut = False", conn);

        cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
        cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

        OdbcDataReader reader = null;
        bool isApproved = false;
        string pwd = "";

        try
        {
          conn.Open();

          reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

          if (reader.HasRows)
          {
            reader.Read();
            pwd = reader.GetString(0);
            isApproved = reader.GetBoolean(1);
          }
          else
          {
            return false;
          }

          reader.Close();

          if (CheckPassword(password, pwd))
          {
            if (isApproved)
            {
              isValid = true;

              OdbcCommand updateCmd = new OdbcCommand("UPDATE [" + tableName + "] SET LastLoginDate = ?" +
                                                      " WHERE Username = ? AND ApplicationName = ?", conn);

              updateCmd.Parameters.Add("@LastLoginDate", OdbcType.DateTime).Value = DateTime.Now;
              updateCmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
              updateCmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;
 
              updateCmd.ExecuteNonQuery();
            }
          }
          else
          {
            conn.Close();

            UpdateFailureCount(username, "password");
          }
        }
        catch (OdbcException e)
        {
          if (WriteExceptionsToEventLog)
          {
            WriteToEventLog(e, "ValidateUser");

            throw new ProviderException(exceptionMessage);
          }
          else
          {
            throw e;
          }
        }
        finally
        {
          if (reader != null) { reader.Close(); }
          conn.Close();
        }

        return isValid;
      }

        */
        //
        // UpdateFailureCount
        //   A helper method that performs the checks and updates associated with
        // password failure tracking.
        //

        private void UpdateFailureCount(string username, string failureType)
        {
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT FailedPasswordAttemptCount, " +
                                              "  FailedPasswordAttemptWindowStart, " +
                                              "  FailedPasswordAnswerAttemptCount, " +
                                              "  FailedPasswordAnswerAttemptWindowStart " +
                                              "  FROM [" + tableName + "] " +
                                              "  WHERE Username = ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

            OdbcDataReader reader = null;
            DateTime windowStart = new DateTime();
            int failureCount = 0;

            try
            {
                conn.Open();

                reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.HasRows)
                {
                    reader.Read();

                    if (failureType == "password")
                    {
                        failureCount = reader.GetInt32(0);
                        windowStart = reader.GetDateTime(1);
                    }

                    if (failureType == "passwordAnswer")
                    {
                        failureCount = reader.GetInt32(2);
                        windowStart = reader.GetDateTime(3);
                    }
                }

                reader.Close();

                DateTime windowEnd = windowStart.AddMinutes(PasswordAttemptWindow);

                if (failureCount == 0 || DateTime.Now > windowEnd)
                {
                    // First password failure or outside of PasswordAttemptWindow. 
                    // Start a new password failure count from 1 and a new window starting now.

                    if (failureType == "password")
                        cmd.CommandText = "UPDATE [" + tableName + "] " +
                                          "  SET FailedPasswordAttemptCount = ?, " +
                                          "      FailedPasswordAttemptWindowStart = ? " +
                                          "  WHERE Username = ? AND ApplicationName = ?";

                    if (failureType == "passwordAnswer")
                        cmd.CommandText = "UPDATE [" + tableName + "] " +
                                          "  SET FailedPasswordAnswerAttemptCount = ?, " +
                                          "      FailedPasswordAnswerAttemptWindowStart = ? " +
                                          "  WHERE Username = ? AND ApplicationName = ?";

                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@Count", OdbcType.Int).Value = 1;
                    cmd.Parameters.Add("@WindowStart", OdbcType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
                    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

                    if (cmd.ExecuteNonQuery() < 0)
                        throw new ProviderException("Unable to update failure count and window start.");
                }
                else
                {
                    if (failureCount++ >= MaxInvalidPasswordAttempts)
                    {
                        // Password attempts have exceeded the failure threshold. Lock out
                        // the user.

                        cmd.CommandText = "UPDATE [" + tableName + "] " +
                                          "  SET IsLockedOut = ?, LastLockedOutDate = ? " +
                                          "  WHERE Username = ? AND ApplicationName = ?";

                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@IsLockedOut", OdbcType.Bit).Value = true;
                        cmd.Parameters.Add("@LastLockedOutDate", OdbcType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
                        cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

                        if (cmd.ExecuteNonQuery() < 0)
                            throw new ProviderException("Unable to lock out user.");
                    }
                    else
                    {
                        // Password attempts have not exceeded the failure threshold. Update
                        // the failure counts. Leave the window the same.

                        if (failureType == "password")
                            cmd.CommandText = "UPDATE [" + tableName + "] " +
                                              "  SET FailedPasswordAttemptCount = ?" +
                                              "  WHERE Username = ? AND ApplicationName = ?";

                        if (failureType == "passwordAnswer")
                            cmd.CommandText = "UPDATE [" + tableName + "] " +
                                              "  SET FailedPasswordAnswerAttemptCount = ?" +
                                              "  WHERE Username = ? AND ApplicationName = ?";

                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@Count", OdbcType.Int).Value = failureCount;
                        cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
                        cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

                        if (cmd.ExecuteNonQuery() < 0)
                            throw new ProviderException("Unable to update failure count.");
                    }
                }
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "UpdateFailureCount");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                conn.Close();
            }
        }


        //
        // CheckPassword
        //   Compares password values based on the MembershipPasswordFormat.
        //

        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;
                default:
                    break;
            }

            if (pass1 == pass2)
            {
                return true;
            }

            return false;
        }


        //
        // EncodePassword
        //   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
        //

        private string EncodePassword(string password)
        {
            string encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword =
                      Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1();
                    hash.Key = HexToByte(machineKey.ValidationKey);
                    encodedPassword =
                      Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return encodedPassword;
        }


        //
        // UnEncodePassword
        //   Decrypts or leaves the password clear based on the PasswordFormat.
        //

        private string UnEncodePassword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password =
                      Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        //
        // HexToByte
        //   Converts a hexadecimal string to a byte array. Used to convert encryption
        // key values from the configuration.
        //

        private byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        //
        // MembershipProvider.FindUsersByName
        //

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {

            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT Count(*) FROM [" + tableName + "] " +
                      "WHERE Username LIKE ? AND ApplicationName = ?", conn);
            cmd.Parameters.Add("@UsernameSearch", OdbcType.VarChar, 255).Value = usernameToMatch;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

            MembershipUserCollection users = new MembershipUserCollection();

            OdbcDataReader reader = null;

            try
            {
                conn.Open();
                totalRecords = (int)cmd.ExecuteScalar();

                if (totalRecords <= 0) { return users; }

                cmd.CommandText = "SELECT PKID, Username, Email, PasswordQuestion," +
                  " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                  " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate " +
                  " FROM [" + tableName + "] " +
                  " WHERE Username LIKE ? AND ApplicationName = ? " +
                  " ORDER BY Username Asc";

                reader = cmd.ExecuteReader();

                int counter = 0;
                int startIndex = pageSize * pageIndex;
                int endIndex = startIndex + pageSize - 1;

                while (reader.Read())
                {
                    if (counter >= startIndex)
                    {
                        MembershipUser u = GetUserFromReader(reader);
                        users.Add(u);
                    }

                    if (counter >= endIndex) { cmd.Cancel(); }

                    counter++;
                }
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "FindUsersByName");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }

                conn.Close();
            }

            return users;
        }

        //
        // MembershipProvider.FindUsersByEmail
        //

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT Count(*) FROM [" + tableName + "] " +
                                              "WHERE Email LIKE ? AND ApplicationName = ?", conn);
            cmd.Parameters.Add("@EmailSearch", OdbcType.VarChar, 255).Value = emailToMatch;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

            MembershipUserCollection users = new MembershipUserCollection();

            OdbcDataReader reader = null;
            totalRecords = 0;

            try
            {
                conn.Open();
                totalRecords = (int)cmd.ExecuteScalar();

                if (totalRecords <= 0) { return users; }

                cmd.CommandText = "SELECT PKID, Username, Email, PasswordQuestion," +
                         " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
                         " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate " +
                         " FROM [" + tableName + "] " +
                         " WHERE Email LIKE ? AND ApplicationName = ? " +
                         " ORDER BY Username Asc";

                reader = cmd.ExecuteReader();

                int counter = 0;
                int startIndex = pageSize * pageIndex;
                int endIndex = startIndex + pageSize - 1;

                while (reader.Read())
                {
                    if (counter >= startIndex)
                    {
                        MembershipUser u = GetUserFromReader(reader);
                        users.Add(u);
                    }

                    if (counter >= endIndex) { cmd.Cancel(); }

                    counter++;
                }
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "FindUsersByEmail");

                    throw new ProviderException(exceptionMessage);
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }

                conn.Close();
            }

            return users;
        }


        //
        // WriteToEventLog
        //   A helper function that writes exception detail to the event log. Exceptions
        // are written to the event log as a security measure to avoid private database
        // details from being returned to the browser. If a method does not return a status
        // or boolean indicating the action succeeded or failed, a generic exception is also 
        // thrown by the caller.
        //

        private void WriteToEventLog(Exception e, string action)
        {
            EventLog log = new EventLog();
            log.Source = eventSource;
            log.Log = eventLog;

            string message = "An exception occurred communicating with the data source.\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            log.WriteEntry(message);
        }

    }
}
