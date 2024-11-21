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


namespace NetApp.DataTables.Tests
{
    /// <summary>
    /// Represents tests forNetApp.DataTables.AspNet5 naming conventions.
    /// </summary>
    [TestClass]
    public class NameConventionTests
    {
        /// <summary>
        /// Validates CamelCase request name convention.
        /// </summary>
        [TestMethod]
        public void CamelCaseRequestNameConvention()
        {
            // Arrange
            var names = new NameConvention.CamelCaseRequestNameConvention();

            // Assert
            Assert.AreEqual("draw", names.Draw);
            Assert.AreEqual("start", names.Start);
            Assert.AreEqual("length", names.Length);
            Assert.AreEqual("search[value]", names.SearchValue);
            Assert.AreEqual("search[regex]", names.IsSearchRegex);
            Assert.AreEqual("order[{0}][column]", names.SortField);
            Assert.AreEqual("order[{0}][dir]", names.SortDirection);
            Assert.AreEqual("columns[{0}][data]", names.ColumnField);
            Assert.AreEqual("columns[{0}][name]", names.ColumnName);
            Assert.AreEqual("columns[{0}][searchable]", names.IsColumnSearchable);
            Assert.AreEqual("columns[{0}][orderable]", names.IsColumnSortable);
            Assert.AreEqual("columns[{0}][search][value]", names.ColumnSearchValue);
            Assert.AreEqual("columns[{0}][search][regex]", names.IsColumnSearchRegex);
        }

        /// <summary>
        /// Validates CamelCase response name convention.
        /// </summary>
        [TestMethod]
        public void CamelCaseResponseNameConvention()
        {
            // Arrange
            var names = new NameConvention.CamelCaseResponseNameConvention();

            // Assert
            Assert.AreEqual("draw", names.Draw);
            Assert.AreEqual("error", names.Error);
            Assert.AreEqual("data", names.Data);
            Assert.AreEqual("recordsTotal", names.TotalRecords);
            Assert.AreEqual("recordsFiltered", names.TotalRecordsFiltered);
        }

        /// <summary>
        /// Validates HungarianNotation request name convention.
        /// </summary>
        [TestMethod]
        public void HungarianNotationRequestNameConvention()
        {
            // Arrange
            var names = new NameConvention.HungarianNotationRequestNameConvention();

            // Assert
            Assert.AreEqual("sEcho", names.Draw);
            Assert.AreEqual("iDisplayStart", names.Start);
            Assert.AreEqual("iDisplayLength", names.Length);
            Assert.AreEqual("sSearch", names.SearchValue);
            Assert.AreEqual("bRegex", names.IsSearchRegex);
            Assert.AreEqual("sSortCol_{0}", names.SortField);
            Assert.AreEqual("sSortDir_{0}", names.SortDirection);
            Assert.AreEqual("mDataProp_{0}", names.ColumnField);
            Assert.AreEqual("{0}", names.ColumnName);
            Assert.AreEqual("bSearchable_{0}", names.IsColumnSearchable);
            Assert.AreEqual("bSortable_{0}", names.IsColumnSortable);
            Assert.AreEqual("sSearch_{0}", names.ColumnSearchValue);
            Assert.AreEqual("bRegex_{0}", names.IsColumnSearchRegex);
        }

        /// <summary>
        /// Validates HungarianNotation response name convention.
        /// </summary>
        [TestMethod]
        public void HungarianNotationResponseNameConvention()
        {
            // Arrange
            var names = new NameConvention.HungarianNotationResponseNameConvention();

            // Assert
            Assert.AreEqual("sEcho", names.Draw);
            Assert.AreEqual(string.Empty, names.Error);
            Assert.AreEqual("aaData", names.Data);
            Assert.AreEqual("iTotalRecords", names.TotalRecords);
            Assert.AreEqual("iTotalDisplayRecords", names.TotalRecordsFiltered);
        }
    }
}
