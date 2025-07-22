import "@/lib/i18n"; // <--- добавь эту строку!
import { Routes, Route } from 'react-router-dom'
import Header from './components/HomeCompon/Header'
import Home from './pages/Home'
import Food from './pages/Food'
import Reports from './pages/Reports'

function App() {
  return (
    <div className="relative min-h-screen overflow-y-auto">
      {/* Фоновый рисунок */}
      <div className="bg-[url('./public/image.png')] bg-cover bg-center blur-xs absolute inset-0 -z-10" />

      {/* Контент поверх фона */}
      <div className="relative z-10 flex flex-col min-h-screen">
        <Header />

        <main className="flex-grow px-4 max-w-[120rem] mx-auto w-full">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/food" element={<Food />} />
            <Route path="/reports" element={<Reports />} />
          </Routes>
        </main>
      </div>
    </div>
  )
}

export default App
