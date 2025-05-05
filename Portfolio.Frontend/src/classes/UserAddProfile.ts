import { AcademicTitle } from "@/enums/AcademicTitle";
import { AcademicDegree } from "@/enums/AcademicDegree";

export class UserAddProfile {
  id: string;
  email: string;
  lastName: string;
  firstName: string;
  middleName?: string;
  gender: number;
  phone: string;
}
