<?xml version="1.0" encoding="utf-8"?>
<!--
  Title: Atom 0.3 XSL Template
  Author: Rich Manalang (http://manalang.com)
  Description: This sample XSLT will convert any valid Atom 0.3 feed to HTML.
-->
<xsl:stylesheet version="1.0"
  xmlns:atom="http://www.w3.org/2005/Atom"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:dc="http://purl.org/dc/elements/1.1/">
  <xsl:output method="html"/>
  <xsl:template match="/atom:feed">
    <html>
      <head>
        <title>
          <xsl:value-of select="atom:title"/>
        </title>
        <link rel="stylesheet" href="/Xps/App_Themes/Default/atom.css" target="_blank"></link>
      </head>
      <body>
        <div id="feedcontent">
          <div id="wrap2">
            <div id="feedtitle">
              <h1>
                <a>
                  <xsl:attribute name="href">
                    <xsl:value-of select="atom:id"/>
                  </xsl:attribute>
                  <xsl:value-of select="atom:title"/>
                </a>
              </h1>
            </div>
            <div id="rsstagline">
              <p>
                <em>
                  <xsl:value-of select="description"/>
                  <br/>
                  <xsl:value-of select="substring(dc:date,1,10)"/>
                </em>
              </p>
            </div>
            <div id="entrylist">
              <div id="rssmain2">
                <xsl:for-each select="atom:entry">
                  <div class="rssentry">
                    <h2>
                      <a>
                        <xsl:attribute name="href">
                          <xsl:value-of select="atom:id"/>
                        </xsl:attribute>
                        <xsl:value-of select="atom:title"/>
                      </a>
                    </h2>
                    <div class="rsssubject">
                      <xsl:value-of select="dc:subject"/>
                    </div>
                    <div class="rssdate">
                      <xsl:value-of select="atom:updated"/>
                    </div>
                    <div class="rssdescription">
                      <xsl:value-of select="atom:summary" disable-output-escaping="yes"/>
                    </div>
                    <div class="rsslink">
                      <a>
                        <xsl:attribute name="href">
                          <xsl:value-of select="link"/>
                        </xsl:attribute>link to original
                      </a>
                    </div>
                    <div>
                      <xsl:value-of select="atom:content" disable-output-escaping="no"/>
                    </div>
                  </div>
                </xsl:for-each>
              </div>
            </div>
            <em class="clear">&amp;nbsp;</em>
          </div>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>