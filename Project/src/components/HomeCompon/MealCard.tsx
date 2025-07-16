import { Card, CardContent, CardTitle } from "@/components/ui/card"

interface MealCardProps {
  title: string
  calories: number
  protein: number
  fat: number
  carbs?: number
}

export default function MealCard({
  title,
  calories,
  protein,
  fat,
  carbs,
}: MealCardProps) {
  return (
    <Card className="rounded-2xl border bg-white shadow-md p-4">
      <CardContent className="p-0 space-y-2">
        <CardTitle className="text-xs font-medium text-gray-500">{title}</CardTitle>
        <div className="text-2xl font-bold text-black">{calories} кал</div>
        <div className="text-xs text-gray-500 font-medium">
          <span className="text-black">{protein}г</span> б. &nbsp;
          <span className="text-black">{fat}г</span> ж.
          {carbs !== undefined && (
            <>
              &nbsp;<span className="text-black">{carbs}г</span> у.
            </>
          )}
        </div>
      </CardContent>
    </Card>
  )
}
