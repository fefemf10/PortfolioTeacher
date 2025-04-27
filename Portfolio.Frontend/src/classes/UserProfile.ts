import { AcademicDegree } from "@/enums/AcademicDegree";
import { AcademicTitle } from "@/enums/AcademicTitle";
import { Post } from "@/enums/PostEnum";
export class UserProfile {
  id: string;
  email: string;
  lastName: string;
  firstName: string;
  middleName: string;
  academicDegree: AcademicDegree;
  academicTitle: AcademicTitle;
  post: Post;
  publicationCount: number;
  phone: string;
}
