"use client"

import {
  Label,
  PolarGrid,
  PolarRadiusAxis,
  RadialBar,
  RadialBarChart,
} from "recharts"

import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/card'

import type { ChartConfig } from '@/components/ui/chart'
import { ChartContainer } from '@/components/ui/chart'
import { useTranslation } from "react-i18next";

const consumed = 2100;
const goal = 2300;
const percentage = Math.min((consumed / goal) * 100, 100);

const chartData = [
  {
    browser: "safari",
    visitors: consumed,
    fill: "#1127cbff",
  },
];

const chartConfig = {
  visitors: {
    label: "Visitors",
  },
  safari: {
    label: "Safari",
    color: "#1127cbff",
  },
} satisfies ChartConfig;

export default function CalorieProgressCard() {
  const { t } = useTranslation();

  return (
    <Card className="flex flex-col w-full max-w-[430px] mx-auto rounded-xl shadow-md overflow-hidden select-none">
      <CardHeader className="items-center pb-0">
        <CardTitle>
          <p className="text-center text-lg sm:text-2xl font-bold text-black tracking-tight">
            {t('remaining')}
          </p>
        </CardTitle>
      </CardHeader>

      <CardContent className="flex justify-center items-center pb-0 pt-2 px-0">
        <ChartContainer
          config={chartConfig}
          className="w-full max-w-[200px] sm:max-w-[260px] aspect-square"
        >
          <RadialBarChart
            width={180}
            height={180}
            data={chartData}
            startAngle={0}
            endAngle={270}
            innerRadius={60}
            outerRadius={80}
          >
            <PolarGrid gridType="circle" radialLines={false} stroke="none" />
            <RadialBar dataKey="visitors" background cornerRadius={10} />
            <PolarRadiusAxis tick={false} tickLine={false} axisLine={false}>
              <Label
                content={({ viewBox }) => {
                  if (viewBox && "cx" in viewBox && "cy" in viewBox) {
                    return (
                      <text
                        x={viewBox.cx}
                        y={viewBox.cy}
                        textAnchor="middle"
                        dominantBaseline="middle"
                      >
                        <tspan
                          x={viewBox.cx}
                          y={viewBox.cy}
                          className="fill-foreground text-2xl font-bold"
                        >
                          {consumed}
                        </tspan>
                        <tspan
                          x={viewBox.cx}
                          y={(viewBox.cy || 0) + 20}
                          className="fill-muted-foreground text-xs"
                        >
                          {t('calories')}
                        </tspan>
                      </text>
                    )
                  }
                }}
              />
            </PolarRadiusAxis>
          </RadialBarChart>
        </ChartContainer>
      </CardContent>

      <CardFooter className="flex flex-col items-center gap-1 text-sm pt-2">
        <p className="text-muted-foreground font-medium text-center">
          {t('consumed')}: {consumed} {t('of')} {goal} {t('kcal')} ({Math.round(percentage)}%)
        </p>
      </CardFooter>
    </Card>
  );
}
