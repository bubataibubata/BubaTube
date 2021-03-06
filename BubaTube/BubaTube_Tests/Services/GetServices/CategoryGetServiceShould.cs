﻿using BubaTube.Data;
using BubaTube.Services.GetServices;
using BubaTube_Tests.MockData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BubaTube_Tests.Services.GetServices
{
    public class CategoryGetServiceShould
    {
        [Fact]
        public void TakeCategoryIdsReturnsListOfIdsWhenPassedStringsArePresentInDB()
        {
            var options = this.GetOptions("TakeCategoryIdsSavedInDB");
            var searchedCategories = new List<string>() { "Test1", "Test2", "TestTest" };

            using (var context = new BubaTubeDbContext(options))
            {
                var categoryMockDataProvider = new CategoryMockData();
                context.Category.AddRange(categoryMockDataProvider.GetListOfCategoryModels());
                context.SaveChanges();

                var categoryGetService = new CategoryGetService(context);
                var result = categoryGetService.TakeCategoryIds(searchedCategories);

                var test1FromDb = context.Category
                    .FirstOrDefault(x => x.CategoryName == "Test1");

                var test2FromDb = context.Category
                    .FirstOrDefault(x => x.CategoryName == "Test2");
                
                Assert.NotEmpty(result);
                Assert.Equal(2, result.Count());
                Assert.Contains(result, x => x == test1FromDb.Id);
                Assert.Contains(result, x => x == test2FromDb.Id);
            }
        }

        [Fact]
        public void TakeCategoryIdsReturnsEmptyListWhenPassedStringsThatAreNotPresentInDB()
        {
            var options = this.GetOptions("TakeCategoryIdsSavedInDB");
            var searchedCategories = new List<string>() { "TestTest1", "TestTest2", "TestTest" };

            using (var context = new BubaTubeDbContext(options))
            {
                var categoryMockDataProvider = new CategoryMockData();
                context.Category.AddRange(categoryMockDataProvider.GetListOfCategoryModels());
                context.SaveChanges();

                var categoryGetService = new CategoryGetService(context);
                var result = categoryGetService.TakeCategoryIds(searchedCategories);
                
                Assert.Empty(result);
            }
        }

        [Fact]
        public void TakeCategoryIdsReturnsEmptyListWhenPassedStringsCategoryIsNotApproved()
        {
            var options = this.GetOptions("TakeCategoryIdsSavedInDB");
            var searchedCategories = new List<string>() { "Test0" };

            using (var context = new BubaTubeDbContext(options))
            {
                var categoryMockDataProvider = new CategoryMockData();
                context.Category.AddRange(categoryMockDataProvider.GetListOfCategoryModels());
                context.SaveChanges();

                var categoryGetService = new CategoryGetService(context);
                var result = categoryGetService.TakeCategoryIds(searchedCategories);

                Assert.Empty(result);
            }
        }

        private DbContextOptions<BubaTubeDbContext> GetOptions(string name)
        {
            return new DbContextOptionsBuilder<BubaTubeDbContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;
        }
    }
}
