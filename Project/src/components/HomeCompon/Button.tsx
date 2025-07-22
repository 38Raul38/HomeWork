import { Button } from "@/components/ui/button";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";

function AddMealButton() {
  const navigate = useNavigate();
  const { t } = useTranslation();

  return (
    <Button
      onClick={() => navigate("/food")}
      className="w-full bg-blue-600 hover:bg-blue-700 text-white text-base font-medium rounded-xl py-6 select-none"
    >
      {t("add_meal_button")}
    </Button>
  );
}

export default AddMealButton;
