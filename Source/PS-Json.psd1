﻿#
# Module manifest for module 'PsJson'
#
# Generated by: Andrew Nurse <andrew@andrewnurse.net>
#
# Generated on: 5/17/2011
#

@{

# Script module or binary module file associated with this manifest
ModuleToProcess = 'PsJson.dll'

# Version number of this module.
ModuleVersion = '0.6.0.1'

# ID used to uniquely identify this module
GUID = 'EBBC6424-DD95-40FA-9FFC-07DF99C0491B'

# Author of this module
Author = 'Andrew Nurse <andrew@andrewnurse.net>'

# Company or vendor of this module
CompanyName = 'Unknown'

# Copyright statement for this module
Copyright = '(c) 2011 Andrew Nurse <andrew@andrewnurse.net>. All rights reserved.'

# Description of the functionality provided by this module
Description = 'JSON library for PowerShell'

# Minimum version of the Windows PowerShell engine required by this module
PowerShellVersion = ''

# Name of the Windows PowerShell host required by this module
PowerShellHostName = ''

# Minimum version of the Windows PowerShell host required by this module
PowerShellHostVersion = ''

# Minimum version of the .NET Framework required by this module
DotNetFrameworkVersion = ''

# Minimum version of the common language runtime (CLR) required by this module
CLRVersion = ''

# Processor architecture (None, X86, Amd64, IA64) required by this module
ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
RequiredModules = @()

# Assemblies that must be loaded prior to importing this module
RequiredAssemblies = @('PsJson.dll', 'Newtonsoft.Json.dll')

# Script files (.ps1) that are run in the caller's environment prior to importing this module
ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
TypesToProcess = @('Json.types.ps1xml')

# Format files (.ps1xml) to be loaded when importing this module
FormatsToProcess = @()

# Modules to import as nested modules of the module specified in ModuleToProcess
NestedModules = @('PsJsonScript.psm1')

# Functions to export from this module
FunctionsToExport = '*'

# Cmdlets to export from this module
CmdletsToExport = '*'

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module
AliasesToExport = '*'

# List of all modules packaged with this module
ModuleList = @()

# Private data to pass to the module specified in ModuleToProcess
PrivateData = ''

}