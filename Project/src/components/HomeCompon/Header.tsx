import { NavLink } from 'react-router-dom'

const Header = () => {
  return (
    <header className="flex justify-between items-center px-6 py-4 bg-white shadow-md rounded-xl mb-6">
      <nav className="flex gap-6 text-sm sm:text-base">
        <NavLink
          to="/"
          className={({ isActive }) =>
            isActive
              ? 'text-blue-600 border-b-2 border-blue-600 pb-1 font-semibold'
              : 'text-gray-700 hover:text-blue-500'
          }
        >
          Главная
        </NavLink>

        <NavLink
          to="/food"
          className={({ isActive }) =>
            isActive
              ? 'text-blue-600 border-b-2 border-blue-600 pb-1 font-semibold'
              : 'text-gray-700 hover:text-blue-500'
          }
        >
          Еда
        </NavLink>

        <NavLink
          to="/reports"
          className={({ isActive }) =>
            isActive
              ? 'text-blue-600 border-b-2 border-blue-600 pb-1 font-semibold'
              : 'text-gray-700 hover:text-blue-500'
          }
        >
          Отчёты
        </NavLink>
      </nav>

      <img
        src="/avatar.png"
        alt="User Avatar"
        className="w-10 h-10 rounded-full object-cover"
      />
    </header>
  )
}

export default Header
