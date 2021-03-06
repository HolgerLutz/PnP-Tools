# PnP Changelog
*Please do not commit changes to this file, it is maintained by the repo owner.*

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/).

## [November 2018]

### Added

### Changed
- SharePoint Modernization Framework production release (1.0.1811.0):
	- H4 to H6 elements now retain their formatting when converted to text
	- Combining italic/underline/bold in combination with other type of formatting now works stable
	- Strip out the "zero width space characters"
	- Drop wiki font information
	- Handle additional styles (ms-rteStyle-Quote,ms-rteStyle-IntenseQuote,ms-rteStyle-Emphasis,ms-rteStyle-IntenseEmphasis,ms-rteStyle-References,ms-rteStyle-IntenseReference,ms-rteStyle-Accent1,ms-rteStyle-Accent2)
	- Better handling complex nested styles
	- Full rewrite of indent handling: now supports complex formatting inside indents, indenting of blocks and unlimited indent depth
	- Switch default table style to borderHeaderTableStyleNeutral - this allows highlighted text to show as highlighted, plain table style suppresses this
	- Assume a table width of 800px and spread evenly across available columns
	- Improved reliability in detecting images/videos inside wiki text fragments
	- Clean wiki html before/after processing to drop nodes which are not support in RTE
	- Full rewrite of wiki splitting...better reliability, better results and better performance
- SharePoint.Modernization.Scanner v2.2: massive improvements over the 1.x series
- SharePoint.PermissiveFile.Scanner v1.8: x64 build

## [October 2018]

### Added

### Changed

- SharePoint Modernization Framework production release (1.0.1810.2):
	- Wiki text handling: Headers (H1 to H3), STRONG and EM tags with custom formatting do retain their formatting
	- Supported formatting in table cells is retained when the table html is rewritten
	- Approach to give newly created modern page the same name as the source page has been fixed: now url's to these pages in navigation or other pages are not rewritten
	- Lowered minimal .Net framework version from 4.7 to 4.5.1
	- Expose the swap pages logic so that it can be used by folks using the page transformation engine
	- Support for adding a web part of choice as banner on all generated pages. Used to give end users an option to accept/decline the generated page
	- Fixed issue with default page layout transformation for "One Column with Sidebar" wiki pages
- SharePoint.Modernization.Scanner v1.6: .exe is X64 version only, beta version of classic publishing portal analysis, simplified group connection dashboard
- Tenant Information Portal: settings cleanup [pschaeflein]
- Search query tool 2.8.2: Re-added web based SPO login for some people. Updated to .Net 4.6.2 to support TLS 1.2

## [September 2018]

### Added

- Improvements in the SharePoint Modernization Framework
	- Wiki text handling: Headers (H1 to H3), STRONG and EM tags with custom formatting do retain their formatting

### Changed

## [August 2018]

### Added

### Changed

- SharePoint.UIExperience.Scanner v1.8: Issue tracking list (base template 1100) and Contacts (base template 105) are now supported in modern, custom lists can use gridview in modern (= quick edit) (see https://techcommunity.microsoft.com/t5/Microsoft-SharePoint-Blog/Updates-to-metadata-handling-and-list-templates/ba-p/202113)
- Improvements in the SharePoint Modernization Framework (beta release)
	- Header alignment is retained when transforming wiki text
	- Combined styles (e.g. forecolor with strike-through and fontsize) is now correctly handled when transforming wiki text
	
## [July 2018]

### Added

### Changed

- SharePoint.UIExperience.Scanner v1.7: Switched to use the latest CSOM version + small improvements in the Excel dashboard template
- Lot's of improvements in the SharePoint Modernization Framework (= transforming wiki and web part pages to client side modern pages):
	- Page title handling got improved
	- Documentation for functions and selectors is now autogenerated
	- Improved handing of BR tags
	- Support for having text before and after the web part but inside the div surrounding the web part
	- Theme colors are transformed now
	- Source page item level permissions are copied to the target page (can be optionally turned off)
	- Improved reliability in handling image url's outside of the current web
	- Fixed layout transformation for HeaderRightColumnBody and HeaderLeftColumnBody web part page layouts
	- Fixed "duplicate key" issue when transforming multiple pages in sequence
	- Fixed ListId datatype in model
	- Calendar is now transformed to the Events web part
	- Tasks web part is not transformed anymore
	- Correctly identify a discussionboard

## [June 2018]

### Added

### Changed

- SharePoint.UIExperience.Scanner v1.6: Add Excel based "List and library readiness for modern UI" report generation
- SharePoint.Modernization.Scanner v1.5: Add Excel based "Group connection readiness" and "Page transformation readiness" report generation
- SharePoint.Modernization.Scanner v1.4: page webpart mapping percentage and unmapped web parts column + additional commandline options to control the export of web part properties and use of search for site/page usage information

## [May 2018]

### Added

- First preview version of page migration tech that can be used to transform wiki and webpart pages into modern client side pages

### Changed

- Search query tool v2.8.1: Updated PSSQT version [trevis62]

## [April 2018]

### Added

### Changed

- Search query tool v2.8: Removed old SPO login as it fails too often. Fixed ADAL login for viewing all properties
- SharePoint.Modernization.Scanner v1.3: Site usage information being included
- SharePoint.Modernization.Scanner v1.2: Reliability improvements
- SharePoint.PermissiveFile.Scanner v1.6: Reliability improvements
- SharePoint.Visio.Scanner v1.1: Also scan SiteAssets library for web part pages + reliability improvements
- SharePoint Scanning Framework: Using March PnP Sites Core version + improved reliability/output writing in sample scanner


### Deprecated

## [March 2018]

### Added

- SharePoint.Visio.Scanner v1.0: Scanner to help support upcoming Visio Web Access deprecation (https://blogs.msdn.microsoft.com/visio/2017/09/25/migrate-from-visio-web-access-to-visio-online)
- Script to rename html/html files in a site to aspx (RemediateSiteCollection.ps1, see SharePoint.PermissiveFile.Scanner) 

### Changed

- SharePoint.UIExperience.Scanner v1.5: Reliability improvements + always log list basetemplate value
- SharePoint.PermissiveFile.Scanner v1.5: Improved output writing approach to increase performance
- SharePoint.PermissiveFile.Scanner v1.4: Allow site scoping via -r or -v parameter

### Deprecated
