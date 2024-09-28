import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { UsercardsComponent } from "./User/user/usercards/usercards.component";
import { UsermaintenanceComponent } from "./User/user/usermaintenance/usermaintenance.component";
import { UserlistComponent } from "./User/user/userlist/userlist.component";

const routes: Routes = [
  {
    path: "",
    redirectTo: "/user/list",
    pathMatch: "full",
  },
  {
    path: "user",
    children: [
      { path: "card", component: UsercardsComponent },
      { path: "maintenance", component: UsermaintenanceComponent },
      { path: "maintenance/:documentNumber", component: UsermaintenanceComponent },
      { path: "list", component: UserlistComponent },
    ],
  },
  { path: "**", redirectTo: "/user/list" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
