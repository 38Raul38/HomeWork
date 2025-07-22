import { useState } from "react";
import { useTranslation } from "react-i18next";

type Props = {
  onTabChange: (tab: string) => void
}

const tabKeys = ["today", "recent", "frequent"];

const FoodNavBar = ({ onTabChange }: Props) => {
  const { t } = useTranslation();
  const [activeTab, setActiveTab] = useState(tabKeys[0]);

  const handleClick = (tab: string) => {
    setActiveTab(tab);
    onTabChange(tab);
  };

  return (
    <div className="space-y-4">
      <div className="flex space-x-6 border-b border-gray-200">
        {tabKeys.map((tab) => (
          <button
            key={tab}
            onClick={() => handleClick(tab)}
            className={`pb-2 transition-colors ${
              activeTab === tab
                ? "text-blue-600 border-b-2 border-blue-600 font-semibold"
                : "text-gray-600 hover:text-blue-500"
            }`}
          >
            {t(tab)}
          </button>
        ))}
      </div>
    </div>
  );
};

export default FoodNavBar;
