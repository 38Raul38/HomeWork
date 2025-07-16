import React from "react";

type MacroStatsProps = {
  protein: number;
  fat: number;
  carbs: number;
  calories: number;
  proteinGoal?: number;
  fatGoal?: number;
  carbsGoal?: number;
};

const MacroStats: React.FC<MacroStatsProps> = ({
  protein,
  fat,
  carbs,
  calories,
  proteinGoal = 150,
  fatGoal = 70,
  carbsGoal = 200,
}) => {
  const getPercent = (value: number, goal: number): number =>
    Math.min((value / goal) * 100, 100);

  return (
    <div className="flex flex-col items-center justify-center w-full space-y-4">
      {/* Калории и макросы сверху */}
      <div className="text-center space-y-1">
        <p className="text-[48px] font-extrabold leading-tight text-black">{calories}</p>
        <p className="text-sm text-gray-500 mb-2">калорий</p>
        <div className="flex gap-4 text-sm font-medium text-black">
          <span>
            <span className="font-bold text-blue-500">{protein}г</span>{" "}
            <span className="text-gray-500">б.</span>
          </span>
          <span>
            <span className="font-bold text-yellow-500">{fat}г</span>{" "}
            <span className="text-gray-500">ж.</span>
          </span>
          <span>
            <span className="font-bold text-green-500">{carbs}г</span>{" "}
            <span className="text-gray-500">у.</span>
          </span>
        </div>
      </div>

      {/* Прогресс-бары */}
      <div className="w-full max-w-xs space-y-3">
        {/* Белки */}
        <div>
          <div className="flex justify-between text-sm mb-1">
            <span className="flex items-center gap-1">🥩 Белки</span>
            <span className="text-blue-500 font-semibold">
              {protein}г / {proteinGoal}г
            </span>
          </div>
          <div className="w-full bg-gray-200 rounded-full h-2">
            <div
              className="bg-blue-500 h-2 rounded-full"
              style={{ width: `${getPercent(protein, proteinGoal)}%` }}
            />
          </div>
        </div>

        {/* Жиры */}
        <div>
          <div className="flex justify-between text-sm mb-1">
            <span className="flex items-center gap-1">🧈 Жиры</span>
            <span className="text-yellow-500 font-semibold">
              {fat}г / {fatGoal}г
            </span>
          </div>
          <div className="w-full bg-gray-200 rounded-full h-2">
            <div
              className="bg-yellow-500 h-2 rounded-full"
              style={{ width: `${getPercent(fat, fatGoal)}%` }}
            />
          </div>
        </div>

        {/* Углеводы */}
        <div>
          <div className="flex justify-between text-sm mb-1">
            <span className="flex items-center gap-1">🍞 Углеводы</span>
            <span className="text-green-500 font-semibold">
              {carbs}г / {carbsGoal}г
            </span>
          </div>
          <div className="w-full bg-gray-200 rounded-full h-2">
            <div
              className="bg-green-500 h-2 rounded-full"
              style={{ width: `${getPercent(carbs, carbsGoal)}%` }}
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default MacroStats;
