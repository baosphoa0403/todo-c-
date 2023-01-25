using System;
using Study.Models;

namespace Study.Services
{
	public class ProductService: List<ProductModel>
	{
		public ProductService()
		{
			this.AddRange(new ProductModel[]
			{
				new ProductModel()
				{
					Id = 1,
					Name = "Iphone X",
					Price = 2300
				},
                new ProductModel()
                {
                    Id = 2,
                    Name = "Iphone XX",
                    Price = 2300
                },
                new ProductModel()
                {
                    Id = 3,
                    Name = "Iphone XXX",
                    Price = 2300
                },


            });
		}
	}
}

