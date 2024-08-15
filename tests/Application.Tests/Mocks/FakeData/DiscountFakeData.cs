﻿using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class DiscountFakeData : BaseFakeData<Discount, Guid>
{
    public override List<Discount> CreateFakeData()
    {
        List<Discount> data =new() {
        new(Guid.NewGuid(),10,"Fürsət endirim","Ela bir endirim"),
        new(Guid.NewGuid(),13,"Fürsət","Ela bir endirim"),
        new(Guid.NewGuid(),20,"Yaz endirimLəri","Qacirma"),
        };

        return data;
    }
}
