import React from "react";
import FoodItem from "./FoodItem";
import FoodButton from "./FoodButton";
import { useTranslation } from "react-i18next";

interface FoodSectionProps {
  icon: React.ReactNode;
  title: string;
  foods: { name: string; subtitle?: string; calories: number }[];
  onAddFood?: () => void;
}

const FoodSection: React.FC<FoodSectionProps> = ({
  icon,
  title,
  foods,
  onAddFood,
}) => {
  const totalCalories = foods.reduce((sum, f) => sum + f.calories, 0);
const { t } = useTranslation();
  return (
    <div className="mb-5">
      <div className="flex items-center justify-between">
        <div className="flex items-center gap-2">
          <span className="text-2xl">{icon}</span>
          <span className="font-bold text-lg">{title}</span>
        </div>
        <FoodButton onClick={onAddFood} />
      </div>
      <div className="ml-8">
        {foods.length > 0 ? (
          foods.map((f, i) => (
            <FoodItem key={i} name={f.name} subtitle={f.subtitle} calories={f.calories} />
          ))
        ) : (
          <div className="text-gray-400 text-sm mt-1">0 kcal</div>
        )}
        {foods.length > 0 && (
          <div className="text-gray-500 text-xs mt-1">{t('total')}: {totalCalories} {t('kcal')}</div>
        )}
      </div>
    </div>
  );
};

export default FoodSection;
