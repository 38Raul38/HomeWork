import React from "react";
import FoodSection from "./FoodSection";

interface FoodListProps {
  meals: {
    icon: React.ReactNode;
    title: string;
    foods: { name: string; subtitle?: string; calories: number }[];
  }[];
}

const FoodList: React.FC<FoodListProps> = ({ meals }) => (
  <div>
    {meals.map((meal, idx) => (
      <FoodSection
        key={meal.title}
        icon={meal.icon}
        title={meal.title}
        foods={meal.foods}
        onAddFood={() => alert(`Add food in ${meal.title}`)}
      />
    ))}
  </div>
);

export default FoodList;
