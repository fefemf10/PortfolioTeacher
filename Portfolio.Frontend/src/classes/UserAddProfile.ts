import { AcademicTitle } from "../enums/AcademicTitle";
import { AcademicDegree } from "../enums/AcademicDegree";
import { Post } from "../enums/PostEnum";

export class UserAddProfile {
  id: string;
  email: string;
  lastName: string;
  firstName: string;
  middleName?: string;
  phone: string;
  facultyId: string;
  departmentId?: string;
}
