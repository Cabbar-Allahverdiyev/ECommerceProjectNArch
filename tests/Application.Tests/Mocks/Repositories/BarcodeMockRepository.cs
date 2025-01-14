using Application.Features.Barcodes.Profiles;
using Application.Features.Barcodes.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class BarcodeMockRepository : BaseMockRepository<IBarcodeRepository, Barcode, Guid, MappingProfiles, BarcodeBusinessRules, BarcodeFakeData>
{
    public BarcodeMockRepository(BarcodeFakeData fakeData) : base(fakeData)
    {
    }
}
