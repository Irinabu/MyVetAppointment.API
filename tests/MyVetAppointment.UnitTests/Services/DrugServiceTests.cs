﻿using Application.UnitTests;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Data.Exceptions;
using System.Net;

namespace MyVetAppointment.UnitTests.Services
{
    public class DrugServiceTests
    {
        private readonly IDrugService drugServiceMock;
        private readonly DITests diKernel;

        public DrugServiceTests()
        {
            diKernel = new DITests();
            drugServiceMock = diKernel.ResolveService<IDrugService>();
        }

        [Fact]
        public async void Should_PostDrug()
        {
            var drugService = diKernel.ResolveService<IDrugService>();
        
            var drug = new DrugRequest()
            {
                Name = "Paracetamol",
                TotalQuantity = 50
            };
        
            var drugResponse = await drugService.AddDrugAsync(drug);
            Assert.False(string.IsNullOrEmpty(drugResponse.Name));
        }
        
        [Fact]
        public async void Should_GetDrugs()
        {
            var drugService = diKernel.ResolveService<IDrugService>();

            var drugResponse = await drugService.GetAllDrugsAsync();
            Assert.True(drugResponse.Count > 0);
        }
        
        [Fact]
        public async void Should_UpdateDrug()
        {
            var drugService = diKernel.ResolveService<IDrugService>();
            var drugModel = new DrugRequest()
            {
                Name = "Paracetamol",
                TotalQuantity = 70
            };
            var drugResponse =
                await drugService.UpdateDrugAsync(drugModel, Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa89c"));
            Assert.False(string.IsNullOrEmpty(drugResponse.Name));
        } 
        
        [Fact]
        public async void Should_NOT_UpdateDrug()
        {
            var drugService = diKernel.ResolveService<IDrugService>();
            var drugModel = new DrugRequest()
            {
                Name = "Panadol",
                Price = 20,
                TotalQuantity = 70,
                ExpirationDate = DateTime.MaxValue
            };
           
            await Assert.ThrowsAsync<RecordNotFoundException>(() => drugService.UpdateDrugAsync(drugModel, Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa812")));
        }
        
        [Fact]
        public async void Should_DeleteDrug()
        {
            var drugService = diKernel.ResolveService<IDrugService>();
            
            var drugResponse =
                await drugService.DeleteDrugAsync(Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa89c"));
            Assert.False(string.IsNullOrEmpty(drugResponse.Name));
        } 
        
        [Fact]
        public async void Should_NOT_DeleteDrug()
        {
            var drugService = diKernel.ResolveService<IDrugService>();
           
            await Assert.ThrowsAsync<RecordNotFoundException>(() => drugService.DeleteDrugAsync( Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa812")));
        }
    }
}
