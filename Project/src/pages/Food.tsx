import { useState } from "react";
import { useTranslation } from "react-i18next";
import FoodNavBar from "@/components/FoodCompon/FoodTabNav";
import { Input } from "@/components/FoodCompon/Input";
import CreateRecipeButton from "@/components/FoodCompon/CreateRecipeButton";
import FoodList from "@/components/FoodCompon/FoodList";

const Food = () => {
  const { t } = useTranslation();
  const [tab, setTab] = useState("today");

  // Переводим все значения
  const meals = [
    {
      icon: <span className="text-pink-500 text-2xl">🍳</span>,
      title: t("breakfast"),
      foods: [
        { name: t("oatmeal"), subtitle: t("1_cup"), calories: 150 }
      ],
    },
    {
      icon: <span className="text-purple-500 text-2xl">🥗</span>,
      title: t("lunch"),
      foods: [
        { name: t("grilled_chicken_salad"), subtitle: t("1_serving"), calories: 350 }
      ],
    },
    {
      icon: <span className="text-yellow-500 text-2xl">🍽️</span>,
      title: t("dinner"),
      foods: [],
    }
  ];

  return (
    <div className="w-full flex flex-col items-center justify-start pt-12 overflow-x-hidden bg-cover" style={{ backgroundImage: "url('/image.png')" }}>
      <div className="max-w-md w-full mx-auto p-4 sm:p-6 bg-white/90 backdrop-blur-lg rounded-2xl shadow-xl">
        <FoodNavBar onTabChange={setTab} />
        <div className="space-y-3 pt-2">
          <Input placeholder={t("search")} />
          <CreateRecipeButton />
        </div>
        {tab === "today" && (
          <FoodList meals={meals} />
        )}
        {tab === "recent" && (
          <p className="text-gray-500">{t("tab_recent")}</p>
        )}
        {tab === "frequent" && (
          <p className="text-gray-500">{t("tab_frequent")}</p>
        )}
      </div>
    </div>
  );
};

export default Food;
