<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:dc="http://purl.org/dc/elements/1.1/"
    >
  <xsl:template match="/rss/channel">
    <html>
      <head>
        <title>
          GMAN: <xsl:value-of select="title"/>
        </title>
        <link rel="stylesheet" href="/Xps/App_Themes/Default/rss.css" />
      </head>
      <body>
        <div id="wrap">
          <div id="wrap2">
            <div id="rssheader">
              <h1>
                <a>
                  <xsl:attribute name="href">
                    <xsl:value-of select="link"/>
                  </xsl:attribute>
                  <xsl:value-of select="title"/>
                </a> XSLT Example
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
            <div id="rsscontent">
              <div id="rssmain">
                <div id="rssmain2">
                  <xsl:for-each select="item">
                    <div class="rssentry">
                      <h2>
                        <a>
                          <xsl:attribute name="href">
                            <xsl:value-of select="link"/>
                          </xsl:attribute>
                          <xsl:value-of select="title"/>
                        </a>
                      </h2>
                      <div class="rsssubject">
                        <xsl:value-of select="dc:subject"/>
                      </div>
                      <div class="rssdate">
                        <xsl:value-of select="substring(dc:date,1,10)"/>
                      </div>
                      <div class="rssdescription">
                        <xsl:value-of select="description" disable-output-escaping="yes"/>
                      </div>
                      <div class="rsslink">
                        <a>
                          <xsl:attribute name="href">
                            <xsl:value-of select="link"/>
                          </xsl:attribute>link to original
                        </a>
                        <span>
                          <xsl:attribute name="onclick">
                            <xsl:text>PlayYouTubeVideo('</xsl:text><xsl:value-of select="enclosure/@url"/>
                            <xsl:text>')</xsl:text>
                          </xsl:attribute>Play</span>
                        
                      </div>
                      <div>
                        <!--
                        <object width="480" height="395">
                          <param name="allowScriptAccess" value="sameDomain"/>
                          <param name="movie">
                            <xsl:attribute name="value">
                              <xsl:value-of select="enclosure/@url"/>
                            </xsl:attribute>
                          </param>
                              <param name="FlashVars" value="autoplay=0"/>
                                <param name="wmode" value="transparent"/>
                          <embed FlashVars="autoplay=0" width="480" height="395" allowScriptAccess="sameDomain" wmode="transparent" type="application/x-shockwave-flash">
                            <xsl:attribute name="src">
                              <xsl:value-of select="enclosure/@url"/>
                            </xsl:attribute>
                          </embed>
                        </object>
                        -->
                      </div>
                    </div>
                  </xsl:for-each>
                </div>
              </div>
              <div id="sidebar">
                
              </div>

              <em class="clear">&amp;nbsp;</em>
            </div>


          </div>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

