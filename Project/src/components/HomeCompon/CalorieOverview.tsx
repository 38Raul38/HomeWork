import { Card, CardContent } from "@/components/ui/card"
import CalorieProgress from "@/components/HomeCompon/CalorieProgress"
import MacroStats from "@/components/HomeCompon/MacroStats"

export default function CalorieOverview() {
  return (
    <Card className="rounded-2xl p-4">
      <CardContent className="p-0 flex flex-col sm:flex-row items-center sm:items-start justify-between gap-6">
        <CalorieProgress />
          <MacroStats
            protein={35}
            fat={22}
            carbs={89}
            calories={2100}
          />
      </CardContent>
    </Card>
  )
}
