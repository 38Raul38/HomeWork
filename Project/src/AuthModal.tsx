import React, { useState } from "react";
import { useTranslation } from "react-i18next";
import { authSchema } from "./components/validations/authSchema";

interface AuthModalProps {
  open: boolean;
  onClose: () => void;
}

interface AuthForm {
  email: string;
  password: string;
}

type AuthFormErrors = Partial<Record<keyof AuthForm, string>>;

const AuthModal: React.FC<AuthModalProps> = ({ open, onClose }) => {
  const { t } = useTranslation();
  const [form, setForm] = useState<AuthForm>({ email: "", password: "" });
  const [errors, setErrors] = useState<AuthFormErrors>({});

  if (!open) return null;

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const result = authSchema.safeParse(form);

    if (!result.success) {
      const zodErrors: AuthFormErrors = {};
      result.error.issues.forEach(err => {
        const field = err.path[0] as keyof AuthForm;
        zodErrors[field] = t(err.message); // вот тут переводим!
      });
      setErrors(zodErrors);
      return;
    }
    setErrors({});
    alert("Success! (логика авторизации здесь)");
    onClose();
  };

  return (
    <div className="fixed inset-0 bg-black/40 flex items-center justify-center z-50">
      <div className="bg-white rounded-2xl shadow-2xl p-8 min-w-[320px] relative">
        <button
          className="absolute top-3 right-4 text-gray-500 hover:text-black text-2xl"
          onClick={onClose}
        >
          &times;
        </button>
        <h2 className="text-xl font-bold mb-4 text-center">{t("login_register")}</h2>
        <form className="flex flex-col gap-4" onSubmit={handleSubmit} noValidate>
          <div>
            <input
              type="email"
              name="email"
              placeholder={t("email")}
              className={`border px-3 py-2 rounded-lg w-full ${errors.email ? "border-red-500" : ""}`}
              value={form.email}
              onChange={e => setForm({ ...form, email: e.target.value })}
              autoComplete="username"
            />
            {errors.email && (
              <div className="text-xs text-red-600 mt-1">{errors.email}</div>
            )}
          </div>
          <div>
            <input
              type="password"
              name="password"
              placeholder={t("password")}
              className={`border px-3 py-2 rounded-lg w-full ${errors.password ? "border-red-500" : ""}`}
              value={form.password}
              onChange={e => setForm({ ...form, password: e.target.value })}
              autoComplete="current-password"
            />
            {errors.password && (
              <div className="text-xs text-red-600 mt-1">{errors.password}</div>
            )}
          </div>
          <button
            type="submit"
            className="bg-blue-600 text-white py-2 rounded-lg font-semibold"
          >
            {t("login")}
          </button>
        </form>
        <div className="mt-4 text-center text-gray-500 text-sm">
          {t("no_account")} <a href="#" className="text-blue-600 hover:underline">{t("register")}</a>
        </div>
      </div>
    </div>
  );
};

export default AuthModal;
