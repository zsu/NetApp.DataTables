using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetApp.DataTables.Tests
{
    [TestClass]
    public class ColumnTests
    {
        [TestMethod]
        public void NonSearchableColumn()
        {
            // Arrange
            var column = TestHelper.MockColumn("mockName", "mockField", false, true);

            // Assert
            Assert.AreEqual("mockName", column.Name);
            Assert.AreEqual("mockField", column.Field);
            Assert.AreEqual(false, column.IsSearchable);
            Assert.AreEqual(true, column.IsSortable);
            Assert.AreEqual(null, column.Search);
        }

        [TestMethod] 
        public void SearchableColumnWithSearchValue()
        {
            // Arrange
            var column = TestHelper.MockColumn("mockName", "mockField", true, true, "searchValue", true);

            // Assert
            Assert.AreEqual("mockName", column.Name);
            Assert.AreEqual("mockField", column.Field);
            Assert.AreEqual(true, column.IsSearchable);
            Assert.AreEqual(true, column.IsSortable);
            Assert.AreEqual("searchValue", column.Search.Value);
            Assert.AreEqual(true, column.Search.IsRegex);
        }

        [TestMethod]
        public void SearchableColumnWithoutSearchValue()
        {
            // Arrange
            var column = TestHelper.MockColumn("mockName", "mockField", true, true);

            // Assert
            Assert.AreEqual("mockName", column.Name);
            Assert.AreEqual("mockField", column.Field);
            Assert.AreEqual(true, column.IsSearchable);
            Assert.AreEqual(true, column.IsSortable);
            Assert.AreEqual(String.Empty, column.Search.Value);
            Assert.AreEqual(false, column.Search.IsRegex);
        }

        [TestMethod]
        public void SetColumnSortOnSortableColumn()
        {
            // Arrange
            var column = TestHelper.MockColumn("columnName", "columnField", false, true);

            // Act
            var orderSet = column.SetSort(3, "desc");

            // Assert
            Assert.AreEqual(true, orderSet);
            Assert.AreEqual(3, column.Sort.Order);
            Assert.AreEqual(Core.SortDirection.Descending, column.Sort.Direction);
        }

        [TestMethod]
        public void SetColumnSortOnNonSortableColumn()
        {
            // Arrange
            var column = TestHelper.MockColumn("columnName", "columnField", false, false);

            // Act
            var orderSet = column.SetSort(3, "desc");

            // Assert
            Assert.AreEqual(false, orderSet);
            Assert.IsNull(column.Sort);
        }
    }
}