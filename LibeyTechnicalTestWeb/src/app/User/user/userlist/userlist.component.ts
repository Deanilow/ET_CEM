import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import swal from 'sweetalert2';
import { LibeyUsersApiResponse } from 'src/app/entities/apiRespose';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css'],
})
export class UserlistComponent implements OnInit {
  users: LibeyUser[] = [];
  errorMessage: string = '';

  constructor(private userService: LibeyUserService, private router: Router) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  private loadUsers(): void {
    this.userService.GetAll().subscribe({
      next: (response: LibeyUsersApiResponse) =>
        this.handleApiResponse(response),
      error: () => this.showError('Error de conexión al servidor.'),
    });
  }

  private handleApiResponse(response: LibeyUsersApiResponse): void {
    if (!response.status) {
      this.showError(response.message);
    } else {
      this.users = response.data;
    }
  }

  private showError(message: string): void {
    this.errorMessage = message;
    swal.fire('Error', this.errorMessage, 'error');
  }

  New() {
    this.router.navigate(['/user/maintenance']);
  }

  editUser(user: LibeyUser): void {
    this.router.navigate(['/user/maintenance', user.documentNumber]);
  }

  Buscar(searchValue: string): void {
    this.userService.GetAllFilter(searchValue).subscribe({
      next: (response: LibeyUsersApiResponse) =>
        this.handleApiResponse(response),
      error: () => this.showError('Error de conexión al servidor.'),
    });
  }

  deleteUser(user: LibeyUser): void {
    if (user && user.documentNumber) {
      swal
        .fire({
          title: '¿Estás seguro?',
          text: 'Una vez eliminado, no podrás recuperar este usuario!',
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Sí, eliminar!',
          cancelButtonText: 'Cancelar',
        })
        .then((result) => {
          if (result.isConfirmed) {
            this.userService.Delete(user.documentNumber as string).subscribe({
              next: (response) => {
                if (response.status) {
                  swal.fire(
                    'Eliminado!',
                    'El usuario ha sido eliminado.',
                    'success'
                  );

                  this.loadUsers()

                } else {
                  swal.fire('Error', response.message, 'error');
                }
              },
              error: () => {
                swal.fire('Error', 'Error de conexión al servidor.', 'error');
              },
            });
          }
        });
    } else {
      swal.fire(
        'Error',
        'No se puede eliminar el usuario',
        'error'
      );
    }
  }
}
