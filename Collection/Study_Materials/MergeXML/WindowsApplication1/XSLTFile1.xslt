<xsl:stylesheet version="2.0"
     xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
     xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xsl:output indent="yes"/>
  <xsl:param name="overrideFile"/>
  <xsl:template match="/">
    <xsl:call-template name="merge">
      <xsl:with-param name="std" select="."/>
      <xsl:with-param name="ovrd" select="document($overrideFile)"/>
    </xsl:call-template>
  </xsl:template>
  <xsl:template name="merge">
    <xsl:param name="std"/>
    <xsl:param name="ovrd"/>
    <xsl:for-each select="$std/*">
      <xsl:variable name="key" select="@*[1]"/>
      <xsl:variable name="ovr" select="$ovrd/*[local-name() = local-name(current()) and (not($key) or @*[1] = $key)]"/>
      <xsl:if test="count($ovr) = 0">
        <xsl:copy-of select="."/>
      </xsl:if>
      <xsl:if test="count($ovr) = 1 and (not($ovr/@overrideMode) or $ovr/@overrideMode != 'delete')">
        <xsl:choose>
          <xsl:when test="count($ovr/*) = 0 or $ovr/@overrideMode = 'update' or $ovr/@overrideMode = 'replace'">
            <xsl:variable name="current" select="."/>
            <xsl:for-each select="$ovr">
              <xsl:copy>
                <xsl:for-each select="@*[name() != 'overrideMode']|text()[string-length(normalize-space(.))>0]">
                  <xsl:copy/>
                </xsl:for-each>
                <xsl:choose>
                  <xsl:when test="$ovr/@overrideMode = 'replace'">
                    <xsl:copy-of select="*"/>
                  </xsl:when>
                  <xsl:otherwise>
                    <xsl:call-template name="merge">
                      <xsl:with-param name="std" select="$current"/>
                      <xsl:with-param name="ovrd" select="."/>
                    </xsl:call-template>
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:copy>
            </xsl:for-each>
          </xsl:when>
          <xsl:otherwise>
            <xsl:copy>
              <xsl:for-each select="@*|text()[string-length(normalize-space(.))>0]">
                <xsl:copy/>
              </xsl:for-each>
              <xsl:call-template name="merge">
                <xsl:with-param name="std" select="."/>
                <xsl:with-param name="ovrd" select="$ovr"/>
              </xsl:call-template>
            </xsl:copy>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:if>
    </xsl:for-each>
    <xsl:for-each select="$ovrd/*">
      <xsl:variable name="key" select="@*[1]"/>
      <xsl:if test="count($std/*[local-name() = local-name(current()) 
                    and (not($key) or @*[1] = $key)]) = 0">
        <xsl:copy-of select="."/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>