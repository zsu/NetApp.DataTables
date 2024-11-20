[![NuGet](https://img.shields.io/nuget/v/NetApp.DataTables.svg)](https://www.nuget.org/packages/NetApp.DataTables)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

# What is NetApp.DataTables

NetApp.DataTables is a .net server side component for JQuery DataTables.

# NuGet
```xml
Install-Package NetApp.DataTables
```
# Getting started with NetApp.DataTables

  * Register in Startup: 
  ```xml
            services.RegisterDataTables();
  ```
  * Handle JQuery DataTables ajax call:
  ```xml
        public IActionResult PagedData(IDataTablesRequest request)
        {
            var orderColums = request.Columns.Where(x => x.Sort != null);
            ...
            var response = DataTablesResponse.Create(request, data.Count(), filteredData == null ? 0 : filteredData.Count(), dataPage);
            return new DataTablesJsonResult(response, true);
        }
  ```

# License
All source code is licensed under MIT license - http://www.opensource.org/licenses/mit-license.php
