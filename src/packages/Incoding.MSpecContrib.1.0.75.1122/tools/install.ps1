﻿# Runs every time a package is installed in a project

param($installPath, $toolsPath, $package, $project)

# $installPath is the path to the folder where the package is installed.
# $toolsPath is the path to the tools directory in the folder where the package is installed.
# $package is a reference to the package object.
# $project is a reference to the project the package was installed to.

$project.Object.References.Add("Microsoft.CSharp");
$project.Object.References.Add("System.Web.Mvc");
$project.Object.References.Add("System.Web.WebPages");
$project.Object.References.Add("System.Windows.Forms");
