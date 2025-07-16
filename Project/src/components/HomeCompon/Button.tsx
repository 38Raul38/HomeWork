import { Button } from "@/components/ui/button"
import { useNavigate } from "react-router-dom";

function AddMealButton() {

const navigate = useNavigate()

  return (
    <Button
    onClick={() => navigate("/food")}
    className="w-full bg-blue-600 hover:bg-blue-700 text-white text-base font-medium rounded-xl py-6">
      Добавить приём пищи
    </Button>
  )
}

export default AddMealButton;

