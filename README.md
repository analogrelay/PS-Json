PS-Json
========
Provides a Type Accelerator and Adapter for JSON data in PowerShell

Using
-----
0. [Install PS-Get](http://psget.org/pages/Install)
1. Get PS-Json from the PS-Get gallery

    Import-Package PS-Json

2. Create an object from a JSON string

    $j = [json]"{foo:42}"

3. Access properties from the JSON object!

    $j.foo