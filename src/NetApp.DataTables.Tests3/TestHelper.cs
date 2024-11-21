#region Copyright
/* The MIT License (MIT)

Copyright (c) 2014 Anderson Luiz Mendes Matos (Brazil)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion Copyright

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NetApp.DataTables.Tests
{
    /// <summary>
    /// Provides arrange methods and helpers to execute unit tests.
    /// </summary>
    [TestClass]
    public static class TestHelper
    {
        [TestMethod]
        public static Core.IColumn MockColumn(string columnName, string columnField, bool searchable, bool sortable)
        { return new Column(columnName, columnField, searchable, sortable, null); }

        [TestMethod]
        public static Core.IColumn MockColumn(string columnName, string columnField, bool searchable, bool sortable, string searchValue, bool searchRegex)
        { return new Column(columnName, columnField, searchable, sortable, new Search(searchValue, searchRegex)); }

        [TestMethod]
        public static Core.IOptions MockOptions()
        { return new Options(); }

        [TestMethod]
        public static ModelBinder MockModelBinder()
        { return new ModelBinder(); }

        [TestMethod]
        public static Core.IDataTablesRequest MockDataTablesRequest(int draw, int start, int length, Core.ISearch search, IEnumerable<Core.IColumn> columns)
        { return MockDataTablesRequest(draw, start, length, search, columns, null); }

        [TestMethod]
        public static Core.IDataTablesRequest MockDataTablesRequest(int draw, int start, int length, Core.ISearch search, IEnumerable<Core.IColumn> columns, IDictionary<string, object> additionalParameters)
        { return new DataTablesRequest(draw, start, length, search, columns, additionalParameters); }

        [TestMethod]
        public static System.Collections.IEnumerable MockData()
        { return new string[] { "firstElement", "secondElement", "thirdElement" }; }

        [TestMethod]
        public static IDictionary<string, object> MockAdditionalParameters()
        { return new Dictionary<string, object>() { { "firstParameter", "firstValue" }, { "secondParameter", 7 } }; }

        [TestMethod]
        public static Core.ISearch MockSearch(string searchValue, bool isRegex)
        { return new Search(searchValue, isRegex); }

        [TestMethod]
        public static Core.ISort MockSort(int order, string direction)
        { return new Sort(order, direction); }

        [TestMethod]
        public static IEnumerable<Core.IColumn> MockColumns()
        {
            return new Column[]
            {
                        new Column("column0_name", "column0_field", true, true, MockSearch("column0_search_value", true)),
                        new Column("column1_name", "column1_field", true, false, MockSearch("column1_search_value", false)),
                        new Column("column2_name", "column2_field", false, true, MockSearch("column2_search_value", true)),
            };
        }

        [TestMethod]
        public static IDictionary<string, object> ParseAdditionalParameters(ModelBindingContext modelBindingContext)
        {
            var _return = new Dictionary<string, object>();

            var firstParameter = modelBindingContext.ValueProvider.GetValue("firstParameter");
            _return.Add("firstParameter", firstParameter.FirstValue);

            var secondParameter = modelBindingContext.ValueProvider.GetValue("secondParameter");
            _return.Add("secondParameter", Convert.ToInt32(secondParameter.FirstValue));

            return _return;
        }
    }
}
