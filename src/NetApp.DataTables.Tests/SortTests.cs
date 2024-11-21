﻿#region Copyright
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
    [TestClass]
    public class SortTests
    {
        /// <summary>
        /// Validates ascending sort creation.
        /// </summary>
        [TestMethod]
        public void AscendingSortCreation()
        {
            // Arrange
            var options = TestHelper.MockOptions();
            var sort = TestHelper.MockSort(9, options.RequestNameConvention.SortAscending);

            // Assert
            Assert.AreEqual(9, sort.Order);
            Assert.AreEqual(Core.SortDirection.Ascending, sort.Direction);
        }
        /// <summary>
        /// Validates descending sort creation.
        /// </summary>
        [TestMethod]
        public void DescendingSortCreation()
        {
            // Arrange
            var options = TestHelper.MockOptions();
            var sort = TestHelper.MockSort(9, options.RequestNameConvention.SortDescending);

            // Assert
            Assert.AreEqual(9, sort.Order);
            Assert.AreEqual(Core.SortDirection.Descending, sort.Direction);
        }
    }
}
