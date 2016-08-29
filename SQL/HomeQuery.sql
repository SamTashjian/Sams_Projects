select Shopper.ShopperName, Fruit.FruitName
	from Shopper
		inner join Shopper_Fruit
			on Shopper.ShopperID = Shopper_Fruit.ShopperID
				inner join Fruit
					on Shopper_Fruit.FruitID = Fruit.FruitID
				