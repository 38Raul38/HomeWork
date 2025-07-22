import React from "react";
import { useTranslation } from "react-i18next";

const FoodButton: React.FC<{ onClick?: () => void }> = ({ onClick }) => {


  const { t } = useTranslation();
  return (
    <button
      className="bg-blue-900 text-white rounded-lg px-4 py-1 text-sm font-semibold hover:bg-blue-800 transition"
      onClick={onClick}
    >
      + {t('add_food')}
    </button>
  );
};

export default FoodButton;
