# PcPdxClone

This project is a clone of PCpdx, a show listing and event hosting website. 

## Prerequisites

You will need the following things properly installed on your computer.

* [Git](http://git-scm.com/)
* [Microsoft SQL Server Management Studio](https://msdn.microsoft.com/en-us/library/mt238290.aspx)
* [Visual Studio](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx)

## Installation

* `git clone <https://github.com/lawtonB/PcPdx.git>`
* after bulding, in project folder, run:
  * dnx ef migrations add Initial -c ApplicationDbContext
  * dnx ef database update -c ApplicationDbContext
* open project file in visual studio and run
