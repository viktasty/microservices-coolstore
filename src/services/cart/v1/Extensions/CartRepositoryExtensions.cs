using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VND.CoolStore.Services.Cart.Domain;
using VND.Fw.Infrastructure.EfCore.Extensions;
using VND.Fw.Infrastructure.EfCore.Repository;

namespace VND.CoolStore.Services.Cart.v1.Extensions
{
  public static class CartRepositoryExtensions
  {
    public static async Task<Domain.Cart> GetFullCart(
      this IEfQueryRepository<Domain.Cart> cartRepo,
      Guid cartId,
      bool tracking = true)
    {
      var cart = await cartRepo.GetByIdAsync(
        cartId,
        cartQueryable => cartQueryable
          .Include(x => x.CartItems)
          .ThenInclude((CartItem cartItem) => cartItem.Product),
        tracking);

      if (cart == null)
      {
        throw new Exception($"Could not find the cart[{cartId}]");
      }

      return cart;
    }
  }
}
