import Options from "@/components/ReportsCompon/Options";
import { LineCal } from "@/components/ReportsCompon/LineCal";
import { AvgCal } from "@/components/ReportsCompon/AvgCal";
import { useTranslation } from "react-i18next";

const Report = () => {
  const { t } = useTranslation();

  return (
    <div className="w-full flex items-center justify-center bg-cover bg-center"
      style={{ backgroundImage: "url('/bg-food-blur.png')" }}>
      <div className="w-full max-w-3xl flex flex-col items-center justify-center py-10">
        <div className="w-full bg-white/95 rounded-2xl shadow-2xl p-6 flex flex-col gap-6 items-center">
          {/* Period filter */}
          <Options />

          {/* Card grid */}
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6 w-full">
            {/* Calories */}
            <div className="rounded-xl border border-gray-200 bg-white flex flex-col items-center p-4 h-full min-h-[340px]">
              <span className="font-bold text-2xl mb-3 text-center">{t("calories")}</span>
              <LineCal />
            </div>
            {/* Nutrients */}
            <div className="rounded-xl border border-gray-200 bg-white flex flex-col items-center p-4 h-full min-h-[340px]">
              <span className="font-bold text-2xl mb-3 text-center">{t("nutrients")}</span>
              <AvgCal />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Report;
