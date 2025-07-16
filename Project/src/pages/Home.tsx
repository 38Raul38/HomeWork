import MealCard from "@/components/HomeCompon/MealCard";
import MealButton from "@/components/HomeCompon/Button";
import MacroStats from "@/components/HomeCompon/MacroStats";
import CalorieProgress from "@/components/HomeCompon/CalorieProgress";

const Home = () => {
  return (
    <div className="space-y-6">
      <div className="flex flex-col sm:flex-row gap-4">
        {/* Левая часть — Radial Chart */}
        <div className="flex-1">
          <CalorieProgress />
        </div>

        {/* Правая часть — макросы */}
        <div className="flex-1">
          <MacroStats
            protein={35}
            fat={22}
            carbs={89}
            calories={2100}
          />
        </div>
      </div>

      {/* Карточки еды */}
<div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
  <MealCard title="Завтрак" calories={450} protein={35} fat={18} />
  <MealCard title="Обед" calories={700} protein={50} fat={22} />
  <MealCard title="Ужин" calories={850} protein={65} fat={30} />
  <MealCard title="Перекус" calories={150} protein={10} fat={5} carbs={12} />
</div>

      {/* Кнопка */}
      <div className="pt-4">
        <MealButton />
      </div>
    </div>
  );
};

export default Home;
