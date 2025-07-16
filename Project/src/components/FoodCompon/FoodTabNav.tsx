import { useState } from "react"

type Props = {
  onTabChange: (tab: string) => void
}

const FoodNavBar = ({ onTabChange }: Props) => {
  const [activeTab, setActiveTab] = useState("Today")

  const handleClick = (tab: string) => {
    setActiveTab(tab)
    onTabChange(tab)
  }

  return (
    <div className="space-y-4">
      <h1 className="text-2xl font-bold">Food</h1>
      <div className="flex space-x-6 border-b border-gray-200">
        {["Today", "Recent", "Frequent"].map((tab) => (
          <button
            key={tab}
            onClick={() => handleClick(tab)}
            className={`pb-2 transition-colors ${
              activeTab === tab
                ? "text-blue-600 border-b-2 border-blue-600 font-semibold"
                : "text-gray-600 hover:text-blue-500"
            }`}
          >
            {tab}
          </button>
        ))}
      </div>
    </div>
  )
}

export default FoodNavBar
