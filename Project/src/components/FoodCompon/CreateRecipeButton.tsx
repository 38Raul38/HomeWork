import React from "react";
import { useTranslation } from "react-i18next";

const CreateRecipeButton: React.FC<{ onClick?: () => void }> = ({ onClick }) => {
  const { t } = useTranslation();

  return (
    <button
      className="border rounded-lg px-4 py-2 my-3 text-sm font-medium hover:bg-gray-100 transition"
      onClick={onClick}
    >
      + {t("create_recipe")}
    </button>
  );
};

export default CreateRecipeButton;
