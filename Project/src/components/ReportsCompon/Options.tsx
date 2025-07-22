import { useState } from "react";
import { useTranslation } from "react-i18next";

const optionKeys = [
  "last_7_days",
  "last_30_days",
  "last_year",
  "all_time"
];

const Options = () => {
  const { t } = useTranslation();
  const [value, setValue] = useState(optionKeys[0]);

  return (
    <div className="flex items-center space-x-3">
      <span className="text-2xl font-bold">{t("last")}</span>
      <select
        className="block w-[240px] px-3 py-2 text-base rounded-md border border-gray-200 bg-white focus:outline-none focus:ring-2 focus:ring-blue-500"
        value={value}
        onChange={e => setValue(e.target.value)}
      >
        {optionKeys.map(key => (
          <option key={key} value={key}>
            {t(key)}
          </option>
        ))}
      </select>
    </div>
  );
};

export default Options;
