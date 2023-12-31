﻿namespace Talabat.Core.Entities.Order_Aggregate
{
	public class DeliveryMethod : BaseEntity
	{
		public DeliveryMethod()
		{

		}
		public DeliveryMethod(string shortName, string description, string deliveryTime, decimal price)
		{
			ShortName = shortName;
			Description = description;
			DeliveryTime = deliveryTime;
			Price = price;
		}

		public string ShortName { get; set; }
		public string Description { get; set; }
		public string DeliveryTime { get; set; }
		public decimal Price { get; set; }
	}
}
