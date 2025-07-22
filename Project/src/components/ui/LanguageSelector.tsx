import { Globe2, ChevronDown } from "lucide-react";
import { useState, useRef, useEffect } from "react";
import { useTranslation } from "react-i18next";

const LANGUAGES = [
  { code: "ru", label: "RU" },
  { code: "en", label: "EN" },
  { code: "az", label: "AZ" },
];

const LanguageSelector = () => {
  const { i18n } = useTranslation();
  const [open, setOpen] = useState(false);
  const ref = useRef<HTMLDivElement>(null);

  // Закрытие дропа при клике вне
  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      if (ref.current && !ref.current.contains(event.target as Node)) {
        setOpen(false);
      }
    };
    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  const handleChange = (lang: string) => {
    i18n.changeLanguage(lang);
    setOpen(false);
  };

  return (
    <div className="relative" ref={ref}>
      <button
        className="flex items-center gap-2 px-3 py-1 rounded-lg text-blue-600 hover:bg-blue-50 transition font-medium"
        onClick={() => setOpen((o) => !o)}
        type="button"
      >
        <Globe2 className="w-5 h-5" />
        <span className="text-base font-semibold uppercase">
          {LANGUAGES.find((l) => l.code === i18n.language)?.label || "RU"}
        </span>
        <ChevronDown className="w-4 h-4" />
      </button>
      {open && (
        <div className="absolute right-0 z-10 mt-2 bg-white border rounded-lg shadow-lg min-w-[80px]">
          {LANGUAGES.map((lang) => (
            <button
              key={lang.code}
              className={`w-full text-left px-3 py-2 hover:bg-blue-50 ${
                i18n.language === lang.code ? "font-bold text-blue-700" : ""
              }`}
              onMouseDown={() => handleChange(lang.code)}
              type="button"
            >
              {lang.label}
            </button>
          ))}
        </div>
      )}
    </div>
  );
};

export default LanguageSelector;
