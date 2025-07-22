import React from "react";

interface FoodItemProps {
  name: string;
  subtitle?: string;
  calories: number;
}

const FoodItem: React.FC<FoodItemProps> = ({ name, subtitle, calories }) => (
  <div className="flex items-center justify-between px-2 py-1">
    <div>
      <div className="font-medium">{name}</div>
      {subtitle && <div className="text-xs text-gray-500">{subtitle}</div>}
    </div>
    <div className="font-semibold">{calories}</div>
  </div>
);

export default FoodItem;
