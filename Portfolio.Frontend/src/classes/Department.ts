import { DepartmentType } from "@/enums/DepartmentType";

export class Department {
  id: string;
  name: string;
  shortName?: string | null;
  departmentType: DepartmentType;
  childDepartments: Department[];
  parentDepartmentId?: string | null;
}
