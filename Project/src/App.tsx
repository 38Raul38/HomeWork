import { Routes, Route } from 'react-router-dom'
import Header from './components/HomeCompon/Header'
import Home from './pages/Home'
import Food from './pages/Food'
import Reports from './pages/Reports'

function App() {
  return (
    <>
      {/* Шапка сайта */}
      <Header />

      {/* Контент страниц */}
      <main className="p-4 max-w-4xl mx-auto">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/food" element={<Food />} />
          <Route path="/reports" element={<Reports />} />
          <Route path="/button" element={<Food />} />
        </Routes>
      </main>
    </>
  )
}

export default App
