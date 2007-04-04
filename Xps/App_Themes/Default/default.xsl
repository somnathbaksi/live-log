<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:dc="http://purl.org/dc/elements/1.1/"
    >
<xsl:template match="/rss/channel">
<html>
<head>
<title>GMAN: <xsl:value-of select="title"/> XSLT example</title>
<link rel="stylesheet" href="/Xps/App_Themes/Default/default.css" />
</head>
  <body>
      <div id="wrap"><div id="wrap2">
      <div id="rssheader">
    <h1><a><xsl:attribute name="href"><xsl:value-of select="link"/></xsl:attribute><xsl:value-of select="title"/></a> XSLT Example</h1>
      </div>
      <div id="rsstagline"><p><em><xsl:value-of select="description"/><br/><xsl:value-of select="substring(dc:date,1,10)"/></em></p></div>
      <div id="rsscontent">
    <div id="rssmain"><div id="rssmain2">
    <xsl:for-each select="entry">
        <div class="rssentry">
        <h2>
            <a><xsl:attribute name="href"><xsl:value-of select="link"/></xsl:attribute><xsl:value-of select="title"/></a>
        </h2>
        <div class="rsssubject"><xsl:value-of select="dc:subject"/></div>
        <div class="rssdate"><xsl:value-of select="substring(dc:date,1,10)"/></div>
        <div class="rssdescription"><xsl:value-of select="description" disable-output-escaping="yes"/></div>
        <div class="rsslink"><a><xsl:attribute name="href"><xsl:value-of select="link"/></xsl:attribute>link to original</a></div>
        </div>
    </xsl:for-each>
    </div></div>
    <div id="sidebar"><div id="sidebar2">
    <h2 class="sidebar-title">Example Info</h2>
    <p>This page really is XML.  It's just being transformed by
    your browser to look formatted using something called XSLT
    that's built into your browser.  Don't belive me?  Save the page
    and look at it in a text editor.</p>
    <p>The style is borrowed from blogger.com</p>
    <h2 class="sidebar-title">Other Examples</h2>
    <ul>
        <li><a href="rss.xml">rss 0.91</a></li>
        <li><a href="rss.rss1.0.xml">rss 1.0</a></li>
        <li><a href="rss.rss2.0.xml">rss 2.0</a></li>
        <li><a href="rss.atom.xml">atom 0.3</a></li>
    </ul>
    </div></div>

    <em class="clear">&amp;nbsp;</em>
    </div>


    </div></div>
 </body>
 </html>
</xsl:template>
</xsl:stylesheet>

