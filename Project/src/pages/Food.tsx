import { useState } from "react"
import FoodNavBar from "@/components/FoodCompon/FoodTabNav"
import { Input } from "@/components/FoodCompon/Input"
import { Button } from "@/components/ui/button"

const Food = () => {
  const [tab, setTab] = useState("Today")

  return (
    <div className="p-4 max-w-md mx-auto space-y-6">
      <FoodNavBar onTabChange={setTab} />

      {/* Search + Create Recipe */}
      <div className="space-y-3 pt-2">
        <Input placeholder="Search" />
        <Button variant="outline" className="w-full">+ Create Recipe</Button>
      </div>

      {/* Content by tab */}
      {tab === "Today" && (
        <p className="text-gray-500">Вкладка Today</p>
      )}
      {tab === "Recent" && (
        <p className="text-gray-500">Вкладка Recent</p>
      )}
      {tab === "Frequent" && (
        <p className="text-gray-500">Вкладка Frequent</p>
      )}
    </div>
  )
}

export default Food
