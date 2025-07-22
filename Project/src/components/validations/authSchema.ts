import { z } from "zod";

export const authSchema = z.object({
  email: z.string()
    .regex(/^[\w.+-]+@gmail\.com$/, "Must be a valid @gmail.com address"),
  password: z.string()
    .min(8, "Password must be at least 8 characters")
    .regex(/[A-Z]/, "Password must contain at least one uppercase letter")
    .regex(/\d/, "Password must contain at least one number")
    .regex(/[a-zA-Z]/, "Password must contain letters"),
});

// Если нужно, экспортируй тип для TypeScript:
export type AuthForm = z.infer<typeof authSchema>;
