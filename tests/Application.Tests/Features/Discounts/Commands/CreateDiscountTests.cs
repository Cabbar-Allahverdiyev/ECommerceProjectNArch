using Application.Features.Discounts.Commands.Create;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using static Application.Features.Discounts.Commands.Create.CreateDiscountCommand;

namespace Application.Tests.Features.Discounts.Commands;
public class CreateDiscountTests:DiscountMockRepository
{
    private readonly CreateDiscountCommandValidator _validator;
    private readonly CreateDiscountCommand _command;
    private readonly CreateDiscountCommandHandler _handler;

    public CreateDiscountTests(DiscountFakeData fakeData,
                               CreateDiscountCommandValidator validator,
                               CreateDiscountCommand command)
        :base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler =new CreateDiscountCommandHandler(Mapper,MockRepository.Object,BusinessRules);
    }
}
