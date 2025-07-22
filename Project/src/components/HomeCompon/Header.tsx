import { useState } from "react";
import { NavLink } from "react-router-dom";
import { useTranslation } from "react-i18next";
import LanguageSelector from "@/components/ui/LanguageSelector";
import AuthModal from "@/AuthModal";

const Header = () => {
  const { t } = useTranslation();
  const [openAuth, setOpenAuth] = useState(false);

  return (
    <header className="px-4 sm:px-6 lg:px-8 py-4 bg-white shadow-md rounded-xl mb-6 select-none">
      <div className="flex items-center justify-between">
        {/* Левая часть: логотип + навигация */}
        <div className="flex items-center gap-6">
          {/* Лого + название */}
          <div className="flex items-center gap-2">
            <span className="text-2xl font-bold text-gray-800">
              Nutri<span className="text-orange-500">Track</span>
            </span>
          </div>
          {/* Навигация */}
          <nav className="hidden sm:flex gap-6 text-sm sm:text-base">
            <NavLink
              to="/"
              className={({ isActive }) =>
                isActive
                  ? "text-blue-600 border-b-2 border-blue-600 pb-1 font-semibold"
                  : "text-gray-700 hover:text-blue-500 transition"
              }
            >
              {t("main")}
            </NavLink>
            <NavLink
              to="/food"
              className={({ isActive }) =>
                isActive
                  ? "text-blue-600 border-b-2 border-blue-600 pb-1 font-semibold"
                  : "text-gray-700 hover:text-blue-500 transition"
              }
            >
              {t("food")}
            </NavLink>
            <NavLink
              to="/reports"
              className={({ isActive }) =>
                isActive
                  ? "text-blue-600 border-b-2 border-blue-600 pb-1 font-semibold"
                  : "text-gray-700 hover:text-blue-500 transition"
              }
            >
              {t("reports")}
            </NavLink>
          </nav>
        </div>

        {/* Правая часть: язык и аватар */}
        <div className="flex items-center gap-4">
          <LanguageSelector />
          <img
            src="/avatar.png"
            alt="User Avatar"
            className="w-10 h-10 rounded-full object-cover cursor-pointer"
            onClick={() => setOpenAuth(true)}
          />
        </div>
      </div>
      {/* Модальное окно авторизации */}
      <AuthModal open={openAuth} onClose={() => setOpenAuth(false)} />
    </header>
  );
};

export default Header;
