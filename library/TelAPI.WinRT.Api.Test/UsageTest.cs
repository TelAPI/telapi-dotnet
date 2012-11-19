using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace TelAPI.Api.Test
{
    public class UsageTest : TelAPIBaseTest
    {
        [Fact]
        public async Task Can_I_Get_Usage_List()
        {
            var usages = await Client.GetUsages();

            foreach (var usage in usages.Usages)
            {
                Debug.WriteLine("Usage sid : {0} -> {1}", usage.Sid, usage.Product);
            }

            Assert.NotNull(usages);
        }

        [Fact]
        public async Task Can_I_Get_Usage_List__By_Date()
        {
            var usages = await Client.GetUsages(new DateTime(2012, 9, 12));

            foreach (var usage in usages.Usages)
            {
                Debug.WriteLine("Usage sid : {0} -> {1}", usage.Sid, usage.Product);
            }

            Assert.NotNull(usages);
        }

        [Fact]
        public async Task Can_I_Get_Usage_List_By_Product()
        {
            var usages = await Client.GetUsages(Products.InboundCall);

            foreach (var usage in usages.Usages)
            {
                Debug.WriteLine("Usage sid : {0} -> {1}", usage.Sid, usage.Product);
            }

            Assert.NotNull(usages);
        }

        [Fact]
        public async Task Can_I_Get_Usage_List_By_Page_PageSize()
        {
            var usages = await Client.GetUsages(2, 20);

            foreach (var usage in usages.Usages)
            {
                Debug.WriteLine("Usage sid : {0} -> {1}", usage.Sid, usage.Product);
            }

            Assert.NotNull(usages);
        }

        [Fact]
        public async Task Can_I_Get_Usage_List_By_Options()
        {
            var usages = await Client.GetUsages(12, 9, 2012, null, 10, null);

            foreach (var usage in usages.Usages)
            {
                Debug.WriteLine("Usage sid : {0} -> {1}", usage.Sid, usage.Product);
            }

            Assert.NotNull(usages);
        }

        [Fact]
        public async Task Can_I_Get_Usage_By_Sid()
        {
            var usages = await Client.GetUsages();
            var usage = await Client.GetUsage(usages.Usages[0].Sid);

            Assert.NotNull(usage);
            Assert.NotNull(usages);
            Assert.Equal(usage.Sid, usages.Usages[0].Sid);
        }
    }
}
