import { AcademicDegree } from "@/enums/AcademicDegree";
import { AcademicTitle } from "@/enums/AcademicTitle";
import { Post } from "./Post";

export class UserProfile {
  id: string;
  email: string;
  lastName: string;
  firstName: string;
  middleName: string;
  academicDegree: AcademicDegree;
  academicTitle: AcademicTitle;
  posts: Post[];
  publicationCount: number;
  phone: string;
}
