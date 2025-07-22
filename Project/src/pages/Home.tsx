import { useTranslation } from "react-i18next";
import MealCard from "@/components/HomeCompon/MealCard";
import MealButton from "@/components/HomeCompon/Button";
import MacroStats from "@/components/HomeCompon/MacroStats";
import CalorieProgress from "@/components/HomeCompon/CalorieProgress";

const Home = () => {
  const { t } = useTranslation();

  return (
    <div className="w-full flex items-center justify-center px-2 py-4">
      <div className="bg-white/90 backdrop-blur-lg shadow-lg rounded-xl px-4 py-4 sm:px-6 sm:py-6 w-full max-w-5xl flex flex-col gap-4">
        
        {/* Top: Circle + macro */}
        <div className="flex flex-col sm:flex-row gap-3 sm:gap-4">
          <div className="flex-1 flex justify-center items-center scale-[0.85] sm:scale-90">
            <CalorieProgress />
          </div>
          <div className="flex-1 flex justify-center items-center text-sm sm:text-base">
            <MacroStats
              protein={35}
              fat={22}
              carbs={89}
              calories={2100}
            />
          </div>
        </div>

        {/* Middle: Meal cards */}
        <div className="grid grid-cols-2 sm:grid-cols-4 gap-2 text-xs sm:text-sm">
          <MealCard title={t("breakfast")} calories={450} protein={35} fat={18} />
          <MealCard title={t("lunch")} calories={700} protein={50} fat={22} />
          <MealCard title={t("dinner")} calories={850} protein={65} fat={30} />
          <MealCard title={t("snack")} calories={150} protein={10} fat={5} carbs={12} />
        </div>

        {/* Bottom: Button */}
        <div className="text-center pt-2">
          <MealButton />
        </div>
      </div>
    </div>
  );
}

export default Home;
